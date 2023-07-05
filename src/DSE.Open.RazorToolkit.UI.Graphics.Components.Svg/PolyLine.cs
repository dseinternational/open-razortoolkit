// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.Drawing;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

public class PolyLine: SvgContentElement
{
    protected override string OuterElementName => SvgElements.Polyline;

    [Parameter]
    public string? Points { get; set; }

    [Parameter]
    public Color? Stroke { get; set; }

    [Parameter]
    public Length StrokeWidth { get; set; } = Length.Pixels(1);

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, "points", Points);

        builder.AddAttribute(++sequence, "stroke", Stroke?.ToString());

        if (StrokeWidth.Value != 1)
        {
            builder.AddAttribute(++sequence, "stroke-width", StrokeWidth);
        }
        else
        {
            ++sequence;
        }

        return base.AddAttributes(++sequence, builder);
    }
}
