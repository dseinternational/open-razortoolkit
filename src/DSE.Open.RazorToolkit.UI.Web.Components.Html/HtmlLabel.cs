// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlLabel : HtmlTextBlock
{
    /// <summary>
    /// Gets or sets the id of the element that the label provides a caption for.
    /// </summary>
    [Parameter]
    public string? ForId { get; set; }

    protected override string OuterElementName => HtmlElements.Label;

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(sequence, "for", ForId);
        return base.AddAttributes(sequence + 1, builder);
    }
}
