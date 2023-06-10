// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

/// <summary>
/// Groups child <see cref="HtmlInputRadio{TValue}"/> components.
/// </summary>
public class HtmlInputRadioGroup<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : HtmlInputElement<TValue>
{
    private readonly string _defaultGroupName = Guid.NewGuid().ToString("N");
    private HtmlInputRadioContext? _context;

    public override HtmlInputType? InputType => HtmlInputType.Radio;

    /// <summary>
    /// Gets or sets the child content to be rendering inside the <see cref="HtmlInputRadioGroup{TValue}"/>.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter] private HtmlInputRadioContext? CascadedContext { get; set; }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        // On the first render, we can instantiate the InputRadioContext
        if (_context is null)
        {
            var changeEventCallback = EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString);
            _context = new HtmlInputRadioContext(CascadedContext, changeEventCallback);
        }
        else if (_context.ParentContext != CascadedContext)
        {
            // This should never be possible in any known usage pattern, but if it happens, we want to know
            throw new InvalidOperationException("An InputRadioGroup cannot change context after creation");
        }

        // Mutate the InputRadioContext instance in place. Since this is a non-fixed cascading parameter, the descendant
        // InputRadio/InputRadioGroup components will get notified to re-render and will see the new values.
        _context.GroupName = !string.IsNullOrEmpty(Name) ? Name : _defaultGroupName;
        _context.CurrentValue = CurrentValue;
        _context.FieldClass = EditContext?.FieldCssClass(FieldIdentifier);
    }

    // TODO:

    /// <inheritdoc />
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        Debug.Assert(_context != null);

        // Note that we must not set IsFixed=true on the CascadingValue, because the mutations to _context
        // are what cause the descendant InputRadio components to re-render themselves
        builder.OpenComponent<CascadingValue<HtmlInputRadioContext>>(0);
        builder.AddAttribute(2, "Value", _context);
        builder.AddAttribute(3, "ChildContent", ChildContent);
        builder.CloseComponent();
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        return this.TryParseSelectableValueFromString(value, out result, out validationErrorMessage);
    }
}
