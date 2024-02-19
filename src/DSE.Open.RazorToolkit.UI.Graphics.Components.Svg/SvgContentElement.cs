// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

/// <summary>
/// A <see cref="SvgElement"/> that renders a <i>single</i> standard HTML element
/// that supports child content.
/// </summary>
public abstract class SvgContentElement : SvgElement
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override int AddContent(int sequence, RenderTreeBuilder builder)
    {
        Guard.IsNotNull(builder);

        builder.AddContent(++sequence, ChildContent);
        return ++sequence;
    }
}
