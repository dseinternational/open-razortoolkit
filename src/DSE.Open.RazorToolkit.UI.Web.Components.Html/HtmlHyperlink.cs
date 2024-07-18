// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using DSE.Open.RazorToolkit.UI.Abstractions.Html;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlHyperlink : HtmlTextInline
{
#pragma warning disable CA1056 // URI-like properties should not be strings

    [Parameter, EditorRequired]
    public required string NavigateUri { get; set; }

#pragma warning restore CA1056 // URI-like properties should not be strings

    protected override string OuterElementName => HtmlElements.Anchor;

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.AddAttribute(sequence, "href", NavigateUri);
        return base.AddAttributes(sequence + 1, builder);
    }

    protected override void OnParametersSet()
    {
        ArgumentNullException.ThrowIfNull(NavigateUri);
        base.OnParametersSet();
    }
}
