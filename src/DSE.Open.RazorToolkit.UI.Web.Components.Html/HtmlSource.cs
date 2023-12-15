// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlSource : HtmlElement
{
    protected override string OuterElementName => HtmlElements.Source;

    /// <summary>
    /// The MIME media type of the resource.
    /// </summary>
    [Parameter]
    public MimeType Type { get; set; }


    /// <summary>
    /// Address of the media resource.
    /// </summary>
    [Parameter]
    public required string Source { get; set; }


    protected override void OnParametersSet()
    {
        ArgumentException.ThrowIfNullOrEmpty(Source);
        base.OnParametersSet();
    }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.Type, Type.ToTypeString());
        builder.AddAttribute(++sequence, HtmlAttributes.Src, Source);
        return base.AddAttributes(sequence, builder);
    }
}
