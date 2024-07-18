// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

public class Text : SvgPaintedContentElement
{
    protected override string OuterElementName => "text";

    /// <summary>
    /// The x coordinate of the text.
    /// </summary>
    [Parameter]
    public Length? X { get; set; }

    /// <summary>
    /// The y coordinate of the text.
    /// </summary>
    [Parameter]
    public Length? Y { get; set; }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.AddAttribute(++sequence, "x", X);
        builder.AddAttribute(++sequence, name: "y", Y);

        return base.AddAttributes(++sequence, builder);
    }
}
