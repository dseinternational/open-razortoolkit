// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.Drawing;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

public abstract class SvgPaintedContentElement : SvgContentElement
{
    [Parameter]
    public Color? Fill { get; set; }

    [Parameter]
    public Color? Stroke { get; set; }

    [Parameter]
    public Length StrokeWidth { get; set; } = Length.Pixels(1);

    [Parameter]
    public Length? Height { get; set; }

    [Parameter]
    public Length? Width { get; set; }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, "width", Width);
        builder.AddAttribute(++sequence, "height", Height);

        builder.AddAttribute(++sequence, "fill", Fill);

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
