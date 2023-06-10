// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlTableColumn: HtmlElement
{
    [CascadingParameter]
    public required HtmlTableColumnGroup ParentGroup { get; set; }

    protected override string OuterElementName => HtmlElements.Column;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (ParentGroup is null)
        {
            throw new InvalidOperationException($"{nameof(HtmlTableColumn)} must be contained within a {nameof(HtmlTableColumnGroup)}");
        }
    }
}
