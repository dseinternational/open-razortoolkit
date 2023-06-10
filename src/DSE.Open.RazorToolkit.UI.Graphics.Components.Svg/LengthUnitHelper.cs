// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

public static class LengthUnitHelper
{
    public static string GetUnitLabel(LengthUnits unitType)
    {
        return unitType switch
        {
            LengthUnits.User => string.Empty,
            LengthUnits.Em => "em",
            LengthUnits.Ex => "ex",
            LengthUnits.Pixel => "px",
            LengthUnits.Inch => "in",
            LengthUnits.Centimeter => "cm",
            LengthUnits.Millimeter => "mm",
            LengthUnits.Point => "point",
            LengthUnits.Pc => "pc",
            LengthUnits.Percentage => "%",
            _ => throw new InvalidOperationException($"Unsupported {nameof(LengthUnits)} value '{unitType}'")
        };
    }

    public static bool TryParse(string? value, out LengthUnits unitType)
    {
        LengthUnits? parsed = value switch
        {
            null => LengthUnits.User,
            "" => LengthUnits.User,
            "em" => LengthUnits.Em,
            "ex" => LengthUnits.Ex,
            "px" => LengthUnits.Pixel,
            "in" => LengthUnits.Inch,
            "cm" => LengthUnits.Centimeter,
            "mm" => LengthUnits.Millimeter,
            "point" => LengthUnits.Point,
            "pc" => LengthUnits.Pc,
            "%" => LengthUnits.Percentage,
            _ => null,
        };

        if (parsed is not null)
        {
            unitType = parsed.Value;
            return true;
        }

        unitType = default;
        return false;
    }
}
