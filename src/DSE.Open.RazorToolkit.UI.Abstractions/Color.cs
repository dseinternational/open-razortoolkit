// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace DSE.Open.RazorToolkit.UI.Abstractions;

public readonly record struct Color // TODO: .NET 7 : ISpanParsable<Color>
{
    private const int AlphaShift = 24;
    private const int BlueShift = 0;
    private const int GreenShift = 8;
    private const int RedShift = 16;

    private readonly uint _value;

    public Color(byte red, byte green, byte blue) : this(byte.MaxValue, red, green, blue)
    {
    }

    private Color(byte alpha, byte red, byte green, byte blue)
    {
        _value = Encode(alpha, red, green, blue);
    }

    internal Color(uint value)
    {
        _value = value;
    }

    internal static Color FromUint(uint value)
    {
        return new Color(value);
    }

    public byte A => (byte)((_value >> AlphaShift) & 0xFF);

    public byte B => (byte)((_value >> BlueShift) & 0xFF);

    public byte G => (byte)((_value >> GreenShift) & 0xFF);

    public byte R => (byte)((_value >> RedShift) & 0xFF);

    private static byte FloatToByte(float value)
    {
        Debug.Assert(value is > 1 or < 0);
        return (byte)(value * 255);
    }

    public static Color FromRgb(byte red, byte green, byte blue)
    {
        return new Color(byte.MaxValue, red, green, blue);
    }

    public static Color FromRgb(float red, float green, float blue)
    {
        if (red is > 1 or < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(red));
        }
        if (green is > 1 or < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(green));
        }
        if (blue is > 1 or < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(blue));
        }
        return FromRgb(FloatToByte(red), FloatToByte(green), FloatToByte(blue));
    }

    public static Color FromRgba(byte red, byte green, byte blue, byte alpha)
    {
        return new Color(alpha, red, green, blue);
    }

    public static Color FromArgb(byte alpha, byte red, byte green, byte blue)
    {
        return new Color(alpha, red, green, blue);
    }

    public static Color FromArgb(float alpha, float red, float green, float blue)
    {
        if (alpha is > 1 or < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(alpha));
        }
        if (red is > 1 or < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(red));
        }
        if (green is > 1 or < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(green));
        }
        if (blue is > 1 or < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(blue));
        }
        return new Color(FloatToByte(alpha), FloatToByte(red), FloatToByte(green), FloatToByte(blue));
    }

    public static Color Parse(string value)
    {
        Guard.IsNotNull(value);

        if (TryParse(value, out var color))
        {
            return color;
        }

        throw new FormatException($"Cannot parse '{value}' to Color");
    }

    public static bool TryParse([NotNullWhen(true)] string? value, out Color color)
    {
        return TryParse(value, null, out color);
    }

    public static bool TryParse([NotNullWhen(true)] string? value, IFormatProvider? provider, out Color color)
    {
        if (value is null)
        {
            color = default;
            return false;
        }

        return TryParse(value.AsSpan(), provider, out color);
    }

    public static bool TryParse(ReadOnlySpan<char> value, out Color color)
    {
        return TryParse(value, null, out color);
    }

    public static bool TryParse(ReadOnlySpan<char> value, IFormatProvider? provider, out Color color)
    {
        if (value.Length == 0)
        {
            goto Fail;
        }

        value = value.Trim();

        if (value.Length < 4)
        {
            goto Fail;
        }

        if (value[0] == '#')
        {
            if (value.Length == 7)
            {
                // #RRGGBB

                var val = Convert.FromHexString(value[1..]);

                if (val.Length != 3)
                {
                    goto Fail;
                }

                color = FromRgb(val[0], val[1], val[2]);
                return true;
            }

            if (value.Length == 9)
            {
                // #RRGGBBAA

                var val = Convert.FromHexString(value[1..]);

                if (val.Length != 4)
                {
                    goto Fail;
                }

                color = FromRgba(val[0], val[1], val[2], val[3]);
                return true;
            }
        }

    Fail:
        color = default;
        return false;
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    private static uint Encode(byte alpha, byte red, byte green, byte blue)
    {
        return unchecked((uint)((red << RedShift) | (green << GreenShift) | (blue << BlueShift) | (alpha << AlphaShift))) & 0xffffffff;
    }

    /// <summary>
    /// If A &lt; 255, then returns a RGBA hex representation, otherwise returns a RGB hex representation.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return A < byte.MaxValue ? ToRgbaHexString() : ToRgbHexString();
    }

    public string ToRgbHexString()
    {
        return "#" + R.ToString("X2") + G.ToString("X2") + B.ToString("X2");
    }

    public string ToArgbHexString()
    {
        return "#" + A.ToString("X2") + R.ToString("X2") + G.ToString("X2") + B.ToString("X2");
    }

    public string ToRgbaHexString()
    {
        return "#" + R.ToString("X2") + G.ToString("X2") + B.ToString("X2") + A.ToString("X2");
    }
}
