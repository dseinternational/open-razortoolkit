// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlHyperlink : HtmlTextInline
{
    [Parameter, DisallowNull]
    public string? NavigateUri { get; set; }

    protected override string OuterElementName => HtmlElements.Anchor;

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(sequence, "href", NavigateUri);
        return base.AddAttributes(sequence + 1, builder);
    }

    protected override void OnParametersSet()
    {
        Guard.IsNotNull(NavigateUri);
        base.OnParametersSet();
    }
}
