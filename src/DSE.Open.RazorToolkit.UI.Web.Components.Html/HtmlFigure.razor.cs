// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

/// <summary>
/// The <c>&lt;figure&gt;</c> HTML element represents self-contained content, potentially
/// with an optional caption, which is specified using the <c>&lt;figcaption&gt;</c> element.
/// The figure, its caption, and its contents are referenced as a single unit.
/// </summary>
public partial class HtmlFigure : HtmlBlock
{
    protected override string OuterElementName => "figure";

    [Parameter]
    public RenderFragment? CaptionContent { get; set; }
}
