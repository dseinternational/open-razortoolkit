// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

public class SvgContainer : SvgPaintedContentElement
{
    protected override string OuterElementName => SvgElements.Svg;

    [Parameter]
    public string? ViewBox { get; set; }


    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, "version", "1.1");
        builder.AddAttribute(++sequence, "xmlns", "http://www.w3.org/2000/svg");
        builder.AddAttribute(++sequence, "viewBox", ViewBox);

        return base.AddAttributes(++sequence, builder);
    }
}
