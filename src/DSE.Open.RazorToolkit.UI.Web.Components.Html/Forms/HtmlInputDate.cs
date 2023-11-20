// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

/// <summary>
/// An input component for editing date values.
/// Supported types are <see cref="DateTime"/> and <see cref="DateTimeOffset"/>.
/// </summary>
public partial class
    HtmlInputDate<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : HtmlInputElement<TValue>
{
    private const string DateFormat = "yyyy-MM-dd"; // Compatible with HTML 'date' inputs
    private const string DateTimeLocalFormat = "yyyy-MM-ddTHH:mm:ss"; // Compatible with HTML 'datetime-local' inputs
    private const string MonthFormat = "yyyy-MM"; // Compatible with HTML 'month' inputs
    private const string TimeFormat = "HH:mm:ss"; // Compatible with HTML 'time' inputs
    private string _format = default!;
    private string _parsingErrorMessage = default!;

    public override HtmlInputType? InputType => DateType switch
    {
        HtmlInputDateType.Date => HtmlInputType.Date,
        HtmlInputDateType.DateTimeLocal => HtmlInputType.DateTimeLocal,
        HtmlInputDateType.Month => HtmlInputType.Month,
        HtmlInputDateType.Time => HtmlInputType.Time,
        _ => throw new InvalidOperationException($"Unsupported {nameof(HtmlInputType)} '{DateType}'.")
    };

    /// <summary>
    /// Gets or sets the type of HTML input to be rendered.
    /// </summary>
    [Parameter]
    public HtmlInputDateType DateType { get; set; } = HtmlInputDateType.Date;

    /// <summary>
    /// Gets or sets the error message used when displaying an a parsing error.
    /// </summary>
    [Parameter]
    public string ParsingErrorMessage { get; set; } = string.Empty;

    protected string TypeAttributeValue { get; set; } = string.Empty;

    /// <summary>
    /// Constructs an instance of <see cref="InputDate{TValue}"/>
    /// </summary>
    public HtmlInputDate()
    {
        var type = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);

        if (type != typeof(DateTime) &&
            type != typeof(DateTimeOffset) &&
            type != typeof(DateOnly) &&
            type != typeof(TimeOnly))
        {
            throw new InvalidOperationException($"Unsupported {GetType()} type param '{type}'.");
        }
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        (TypeAttributeValue, _format, var formatDescription) = DateType switch
        {
            HtmlInputDateType.Date => ("date", DateFormat, "date"),
            HtmlInputDateType.DateTimeLocal => ("datetime-local", DateTimeLocalFormat, "date and time"),
            HtmlInputDateType.Month => ("month", MonthFormat, "year and month"),
            HtmlInputDateType.Time => ("time", TimeFormat, "time"),
            _ => throw new InvalidOperationException($"Unsupported {nameof(HtmlInputDateType)} '{DateType}'.")
        };

        _parsingErrorMessage = string.IsNullOrEmpty(ParsingErrorMessage)
            ? $"The {{0}} field must be a {formatDescription}."
            : ParsingErrorMessage;
    }

    /// <inheritdoc />
    protected override string FormatValueAsString(TValue? value)
    {
        return value switch
        {
            DateTime dateTimeValue => BindConverter.FormatValue(dateTimeValue, _format, CultureInfo.InvariantCulture),
            DateTimeOffset dateTimeOffsetValue => BindConverter.FormatValue(dateTimeOffsetValue, _format,
            CultureInfo.InvariantCulture),
            DateOnly dateOnlyValue => BindConverter.FormatValue(dateOnlyValue, _format, CultureInfo.InvariantCulture),
            TimeOnly timeOnlyValue => BindConverter.FormatValue(timeOnlyValue, _format, CultureInfo.InvariantCulture),
            _ => string.Empty // Handles null for Nullable<DateTime>, etc.
        };
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result,
        [NotNullWhen(false)] out string? validationErrorMessage)
    {
        if (BindConverter.TryConvertTo(value, CultureInfo.InvariantCulture, out result))
        {
            Debug.Assert(result != null);
            validationErrorMessage = null;
            return true;
        }

        validationErrorMessage = string.Format(CultureInfo.InvariantCulture, _parsingErrorMessage,
        DisplayName ?? FieldIdentifier.FieldName);
        return false;
    }
}
