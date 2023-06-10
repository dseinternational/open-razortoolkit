// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DSE.Open.RazorToolkit.UI.Core.Validation;

public class FluentValidator<TValidator> : ComponentBase where TValidator : IValidator, new()
{
    private static readonly char[] s_separators = { '.', '[' };
    private TValidator _validator;

    [CascadingParameter]
    private EditContext EditContext { get; set; }

    [Parameter]
    public bool ValidateOnChange { get; set; }

    protected override void OnInitialized()
    {
        _validator = new TValidator();
        var messages = new ValidationMessageStore(EditContext);

        if (ValidateOnChange)
        {
            EditContext.OnFieldChanged += (sender, eventArgs) => ValidateModel((EditContext)sender!, messages);
        }

        EditContext.OnValidationRequested += (sender, eventArgs) => ValidateModel((EditContext)sender!, messages);
    }

    private void ValidateModel(EditContext editContext, ValidationMessageStore messages)
    {
        var context = new ValidationContext<object>(editContext.Model);
        var validationResult = _validator.Validate(context);

        messages.Clear();

        foreach (var error in validationResult.Errors)
        {
            var fieldIdentifier = ToFieldIdentifier(editContext, error.PropertyName);
            messages.Add(fieldIdentifier, error.ErrorMessage);
        }

        editContext.NotifyValidationStateChanged();
    }

    private static FieldIdentifier ToFieldIdentifier(EditContext editContext, string propertyPath)
    {
        // This method parses property paths like 'SomeProp.MyCollection[123].ChildProp'
        // and returns a FieldIdentifier which is an (instance, propName) pair. For example,
        // it would return the pair (SomeProp.MyCollection[123], "ChildProp"). It traverses
        // as far into the propertyPath as it can go until it finds any null instance.

        var obj = editContext.Model;

        while (true)
        {
            var nextTokenEnd = propertyPath.IndexOfAny(s_separators);
            if (nextTokenEnd < 0)
            {
                return new FieldIdentifier(obj, propertyPath);
            }

            var nextToken = propertyPath[..nextTokenEnd];
            propertyPath = propertyPath[(nextTokenEnd + 1)..];

            object? newObj;
            if (nextToken.EndsWith("]"))
            {
                // It's an indexer
                // This code assumes C# conventions (one indexer named Item with one param)
                nextToken = nextToken[..^1];
                var prop = obj.GetType().GetProperty("Item");
                var indexerType = prop.GetIndexParameters()[0].ParameterType;
                var indexerValue = Convert.ChangeType(nextToken, indexerType);
                newObj = prop.GetValue(obj, new[] { indexerValue });
            }
            else
            {
                // It's a regular property
                var prop = obj.GetType().GetProperty(nextToken);
                if (prop == null)
                {
                    throw new InvalidOperationException(
                    $"Could not find property named {nextToken} on object of type {obj.GetType().FullName}.");
                }

                newObj = prop.GetValue(obj);
            }

            if (newObj is null)
            {
                // This is as far as we can go
                return new FieldIdentifier(obj, nextToken);
            }

            obj = newObj;
        }
    }
}
