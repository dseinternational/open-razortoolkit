// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

public class Path : SvgPaintedContentElement
{
    protected override string OuterElementName => "path";

    [Parameter]
    public string? DrawCommands { get; set; }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.AddAttribute(++sequence, "d", DrawCommands);

        return base.AddAttributes(++sequence, builder);
    }
}

// TODO:

// PathBuilder ?

public class DrawCommandCollection
{
    // Parse ??
}

public readonly record struct MoveToCommand(double X, double Y)
{
    public override string ToString()
    {
        return $"M {X.ToStringInvariant()} {Y.ToStringInvariant()}";
    }
}

public readonly record struct LineToCommand(double X, double Y)
{
    public override string ToString()
    {
        return $"L {X.ToStringInvariant()} {Y.ToStringInvariant()}";
    }
}

public readonly record struct HorizontalLineToCommand(double X)
{
    public override string ToString()
    {
        return $"H {X.ToStringInvariant()}";
    }
}

public readonly record struct VerticalLineToCommand(double Y)
{
    public override string ToString()
    {
        return $"V {Y.ToStringInvariant()}";
    }
}

