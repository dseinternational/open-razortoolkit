// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.Drawing;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

public class Line : SvgContentElement
{
    protected override string OuterElementName => SvgElements.Line;

    [Parameter]
    public Color? Stroke { get; set; }

    [Parameter]
    public Length StrokeWidth { get; set; } = Length.Pixels(1);

    [Parameter]
    public Length? X1 { get; set; }

    [Parameter]
    public Length? Y1 { get; set; }

    [Parameter]
    public Length? X2 { get; set; }

    [Parameter]
    public Length? Y2 { get; set; }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, "x1", X1);
        builder.AddAttribute(++sequence, name: "y1", Y1);

        builder.AddAttribute(++sequence, "x2", X2);
        builder.AddAttribute(++sequence, name: "y2", Y2);

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
