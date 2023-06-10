// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

public class Ellipse: SvgPaintedContentElement
{
    protected override string OuterElementName => SvgElements.Ellipse;

    /// <summary>
    /// The x position of the ellipse.
    /// </summary>
    [Parameter]
    public Length? CenterX { get; set; }

    /// <summary>
    /// The y position of the ellipse. 
    /// </summary>
    [Parameter]
    public Length? CenterY { get; set; }

    /// <summary>
    /// The radius of the ellipse on the x axis. 
    /// </summary>
    [Parameter]
    public virtual Length? RadiusX { get; set; }

    /// <summary>
    /// The radius of the ellipse on the y axis.
    /// </summary>
    [Parameter]
    public virtual Length? RadiusY { get; set; }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, "cx", CenterX);
        builder.AddAttribute(++sequence, name: "cy", CenterY);
        builder.AddAttribute(++sequence, "rx", RadiusX);
        builder.AddAttribute(++sequence, name: "ry", RadiusY);

        return base.AddAttributes(++sequence, builder);
    }
}
