// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

/// <summary>
/// A dropdown selection component.
/// </summary>
public class HtmlInputSelect<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : HtmlInputElement<TValue>
{
    private readonly bool _isMultipleSelect;

    protected override string OuterElementName => HtmlElements.Select;

    public override HtmlInputType? InputType => null;

    /// <summary>
    /// Constructs an instance of <see cref="InputSelect{TValue}"/>.
    /// </summary>
    public HtmlInputSelect()
    {
        _isMultipleSelect = typeof(TValue).IsArray;
    }

    /// <summary>
    /// Gets or sets the child content to be rendering inside the select element.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        sequence = base.AddAttributes(++sequence, builder);
        builder.AddAttribute(++sequence, HtmlAttributes.Multiple, _isMultipleSelect);
        return sequence;
    }

    protected override int AddBindings(int sequence, RenderTreeBuilder builder)
    {
        sequence = base.AddBindings(++sequence, builder);
        if (_isMultipleSelect)
        {
            builder.AddAttribute(++sequence, HtmlAttributes.Value, BindConverter.FormatValue(CurrentValue)?.ToString());
            builder.AddAttribute(++sequence, "onchange", EventCallback.Factory.CreateBinder<string?[]?>(this, SetCurrentValueAsStringArray, default));
        }
        else
        {
            builder.AddAttribute(++sequence, HtmlAttributes.Value, CurrentValueAsString);
            builder.AddAttribute(++sequence, "onchange", EventCallback.Factory.CreateBinder<string?>(this, value => CurrentValueAsString = value, default));
        }
        return sequence;
    }

    protected override int AddContent(int sequence, RenderTreeBuilder builder)
    {
        builder.AddContent(++sequence, ChildContent);
        return sequence;
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        return this.TryParseSelectableValueFromString(value, out result, out validationErrorMessage);
    }

    /// <inheritdoc />
    protected override string? FormatValueAsString(TValue? value)
    {
        // We special-case bool values because BindConverter reserves bool conversion for conditional attributes.
        if (typeof(TValue) == typeof(bool))
        {
            return (bool)(object)value! ? "true" : "false";
        }

        if (typeof(TValue) == typeof(bool?))
        {
            return value is not null && (bool)(object)value ? "true" : "false";
        }

        return base.FormatValueAsString(value);
    }

    private void SetCurrentValueAsStringArray(string?[]? value)
    {
        CurrentValue = BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out var result)
            ? result
            : default;
    }
}
