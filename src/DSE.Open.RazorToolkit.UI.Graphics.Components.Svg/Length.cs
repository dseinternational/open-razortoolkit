// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Globalization;
using DSE.Open.RazorToolkit.Core;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

// length ::= number ("em" | "ex" | "px" | "in" | "cm" | "mm" | "pt" | "pc" | "%")?
// https://developer.mozilla.org/en-US/docs/Web/SVG/Content_type#length
// https://developer.mozilla.org/en-US/docs/Web/API/SVGLength

public readonly record struct Length(double Value, LengthUnits UnitType = LengthUnits.User)
{
    public static readonly Length Empty;

    public override string ToString()
    {
        return UnitType == LengthUnits.User
            ? Value.ToStringInvariant()
            : Value.ToStringInvariant() + LengthUnitHelper.GetUnitLabel(UnitType);
    }

    public static Length Pixels(double value)
    {
        return new Length(value, LengthUnits.Pixel);
    }

    public static implicit operator Length(double value)
    {
        return new Length(value);
    }

    public static explicit operator Length(string? value)
    {
        return Parse(value);
    }

    public static Length Parse(string? value)
    {
        if (TryParse(value, out var length))
        {
            return length;
        }
        throw new InvalidOperationException($"Could not parse SvgLength '{value}'");
    }

    public static bool TryParse(string? value, out Length length)
    {
        if (!TrySplitNumbersUnits(value, out var numbers, out var label))
        {
            goto Fail;
        }

        if (numbers == string.Empty)
        {
            length = default;
            return true;
        }

        if (!double.TryParse(numbers, NumberStyles.Float, CultureInfo.InvariantCulture, out var numeric))
        {
            goto Fail;
        }

        if (label == string.Empty)
        {
            length = new Length(numeric);
            return true;
        }

        if (!LengthUnitHelper.TryParse(label, out var unitType))
        {
            goto Fail;
        }

        length = new Length(numeric, unitType);
        return true;

    Fail:
        length = default;
        return false;
    }

    private static bool TrySplitNumbersUnits(string? value, out string numbers, out string label)
    {
        if (value is not null)
        {
            for (var i = 0; i < value.Length; i++)
            {
                if (value[i] >= '0' && value[i] <= '9')
                {
                    continue;
                }

                numbers = value[..i];
                label = value[i..].Trim();
                return true;
            }

            // never found non-digit...
            numbers = value;
        }
        else
        {
            numbers = string.Empty;
        }

        label = string.Empty;

        return false;
    }

}
