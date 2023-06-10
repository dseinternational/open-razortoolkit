// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

// length ::= number ("em" | "ex" | "px" | "in" | "cm" | "mm" | "pt" | "pc" | "%")?
// https://developer.mozilla.org/en-US/docs/Web/SVG/Content_type#length
// https://developer.mozilla.org/en-US/docs/Web/API/SVGLength

/// <summary>
/// Specifies the units of a <see cref="Length"/>.
/// </summary>
/// <remarks>
/// Corresponds to SVG_LENGTHTYPE_ constants in SVG DOM, though we do not have a
/// value for SVG_LENGTHTYPE_UNKNOWN.
/// </remarks>
public enum LengthUnits
{
    /// <summary>
    /// Indicates a value in user units.
    /// </summary>
    User,

    /// <summary>
    /// A percentage value was specified.
    /// </summary>
    Percentage,

    /// <summary>
    /// A value was specified using the <c>em</c> units (font size) defined in CSS2.
    /// </summary>
    Em,

    /// <summary>
    /// the 'x-height' of the relevant font
    /// </summary>
    Ex,

    /// <summary>
    /// pixels, relative to the viewing device
    /// </summary>
    Pixel,

    Inch,

    Centimeter,

    Millimeter,

    Point,

    Pc,
}
