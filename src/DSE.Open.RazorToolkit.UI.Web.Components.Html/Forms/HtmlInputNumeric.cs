// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

public abstract class HtmlInputNumeric<TValue> : HtmlInputElement<TValue> where TValue : INumber<TValue>, IMinMaxValue<TValue>
{
    private static readonly TValue? s_defaultStep = (TValue?)NumericInputHelper.GetDefaultStep<TValue>();

    [Parameter]
    public virtual TValue? Minimum { get; set; } = TValue.MinValue;

    [Parameter]
    public virtual TValue? Maximum { get; set; } = TValue.MaxValue;

    [Parameter]
    public TValue? Step { get; set; } = s_defaultStep;

    /// <summary>
    /// Gets or sets the error message used when displaying an a parsing error.
    /// </summary>
    [Parameter]
    public string ParsingErrorMessage { get; set; } = "The {0} field must be a number.";

    /// <inheritdoc />
    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        if (TValue.TryParse(value, CultureInfo.InvariantCulture, out result))
        {
            validationErrorMessage = null;
            return true;
        }

        validationErrorMessage = string.Format(CultureInfo.InvariantCulture, ParsingErrorMessage, DisplayName ?? FieldIdentifier.FieldName);
        return false;
    }

    /// <summary>
    /// Formats the value as a string. Derived classes can override this to determine
    /// the formatting used for <c>CurrentValueAsString</c>.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representation of the value.</returns>
    protected override string? FormatValueAsString(TValue? value)
    {
        // Avoiding a cast to IFormattable to avoid boxing.
        return value switch
        {
            null => null,
            int @int => BindConverter.FormatValue(@int, CultureInfo.InvariantCulture),
            long @long => BindConverter.FormatValue(@long, CultureInfo.InvariantCulture),
            short @short => BindConverter.FormatValue(@short, CultureInfo.InvariantCulture),
            float @float => BindConverter.FormatValue(@float, CultureInfo.InvariantCulture),
            double @double => BindConverter.FormatValue(@double, CultureInfo.InvariantCulture),
            decimal @decimal => BindConverter.FormatValue(@decimal, CultureInfo.InvariantCulture),
            _ => throw new InvalidOperationException($"Unsupported type {value.GetType()}")
        };
    }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.Min, NumericInputHelper.GetAttributeMinValue(Minimum));
        builder.AddAttribute(++sequence, HtmlAttributes.Max, NumericInputHelper.GetAttributeMaxValue(Maximum));
        builder.AddAttribute(++sequence, HtmlAttributes.Step, BindConverter.FormatValue(Step, CultureInfo.InvariantCulture));

        return base.AddAttributes(sequence, builder);
    }

    protected override int AddBindings(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.Value, BindConverter.FormatValue(CurrentValueAsString));

        builder.AddAttribute(++sequence, "onchange", EventCallback.Factory.CreateBinder<string?>(
        this, value => CurrentValueAsString = value, CurrentValueAsString));

        return ++sequence;
    }
}
