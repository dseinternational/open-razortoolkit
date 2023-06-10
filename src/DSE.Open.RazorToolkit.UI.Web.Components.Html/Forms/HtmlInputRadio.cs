// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

/// <summary>
/// An input component used for selecting a value from a group of choices.
/// </summary>
public class HtmlInputRadio<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : HtmlElement
{
    protected override string OuterElementName => HtmlElements.Input;

    /// <summary>
    /// Gets context for this <see cref="HtmlInputRadio{TValue}"/>.
    /// </summary>
    internal HtmlInputRadioContext? Context { get; private set; }

    /// <summary>
    /// Gets or sets the value of this input.
    /// </summary>
    [Parameter]
    public TValue? Value { get; set; }

    /// <summary>
    /// Gets or sets the name of the parent input radio group.
    /// </summary>
    [Parameter] public string? Name { get; set; }

    [CascadingParameter] private HtmlInputRadioContext? CascadedContext { get; set; }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        Context = string.IsNullOrEmpty(Name) ? CascadedContext : CascadedContext?.FindContextInAncestors(Name);

        if (Context == null)
        {
            throw new InvalidOperationException($"{GetType()} must have an ancestor {typeof(HtmlInputRadioGroup<TValue>)} " +
                "with a matching 'Name' property, if specified.");
        }
    }

    /// <inheritdoc />
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        Debug.Assert(Context != null);

        builder.OpenElement(0, "input");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttributeIfNotNullOrEmpty(2, "class", AttributeUtilities.CombineClassNames(AdditionalAttributes, Context.FieldClass));
        builder.AddAttribute(3, "type", "radio");
        builder.AddAttribute(4, "name", Context.GroupName);
        builder.AddAttribute(5, "value", BindConverter.FormatValue(Value?.ToString()));
        builder.AddAttribute(6, "checked", Context.CurrentValue?.Equals(Value));
        builder.AddAttribute(7, "onchange", Context.ChangeEventCallback);
        builder.AddElementReferenceCapture(8, __inputReference => Element = __inputReference);
        builder.CloseElement();
    }
}
