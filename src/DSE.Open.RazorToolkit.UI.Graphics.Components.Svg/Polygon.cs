// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

public class Polygon : SvgPaintedContentElement
{
    protected override string OuterElementName => SvgElements.Polygon;

    [Parameter]
    public string? Points { get; set; }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, "points", Points);

        return base.AddAttributes(++sequence, builder);
    }
}
