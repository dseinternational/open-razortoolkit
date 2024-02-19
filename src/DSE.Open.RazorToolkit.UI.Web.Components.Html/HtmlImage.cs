// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using DSE.Open.RazorToolkit.UI.Abstractions.Html;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlImage : HtmlElement
{
    [Parameter, EditorRequired]
    public required string Source { get; set; }

    [Parameter]
    public string? Alt { get; set; }

    protected override string OuterElementName => HtmlElements.Image;

    protected override void OnParametersSet()
    {
        ArgumentException.ThrowIfNullOrEmpty(Source);
        base.OnParametersSet();
    }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        Guard.IsNotNull(builder);
        builder.AddAttribute(++sequence, HtmlAttributes.Src, Source);
        builder.AddAttribute(++sequence, HtmlAttributes.Alt, Alt);
        return base.AddAttributes(++sequence, builder);
    }
}
