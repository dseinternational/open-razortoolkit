// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

public class Circle : SvgPaintedContentElement
{
    protected override string OuterElementName => SvgElements.Circle;

    /// <summary>
    /// The x position of the center of the circle.
    /// </summary>
    [Parameter]
    public Length? CenterX { get; set; }

    /// <summary>
    /// The y position of the center of the circle.
    /// </summary>
    [Parameter]
    public Length? CenterY { get; set; }

    /// <summary>
    /// The radius of the circle.
    /// </summary>
    [Parameter]
    public Length? Radius { get; set; }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        Guard.IsNotNull(builder);

        builder.AddAttribute(++sequence, "cx", CenterX);
        builder.AddAttribute(++sequence, name: "cy", CenterY);
        builder.AddAttribute(++sequence, "r", Radius);

        return base.AddAttributes(++sequence, builder);
    }
}
