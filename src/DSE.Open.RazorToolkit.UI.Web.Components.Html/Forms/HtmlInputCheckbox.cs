// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

/// <summary>
/// An input component for editing <see cref="bool"/> values.
/// </summary>
public class HtmlInputCheckbox: HtmlInputElement<bool>
{
    public override HtmlInputType? InputType => HtmlInputType.Checkbox;

    /// <inheritdoc />
    protected override bool TryParseValueFromString(string? value, out bool result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        throw new NotSupportedException(
            $"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");
    }

    protected override int AddBindings(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.Checked, BindConverter.FormatValue(CurrentValue));

        builder.AddAttribute(++sequence, "onchange", EventCallback.Factory.CreateBinder<bool>(
            this, value => CurrentValue = value, CurrentValue));

        return ++sequence;
    }
}
