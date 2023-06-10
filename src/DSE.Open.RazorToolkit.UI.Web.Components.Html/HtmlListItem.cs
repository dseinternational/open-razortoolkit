// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlListItem : HtmlContentElement
{
    protected override string OuterElementName => HtmlElements.ListItem;

    [CascadingParameter]
    public required HtmlList ParentList { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (ParentList is null)
        {
            throw new InvalidOperationException($"{nameof(HtmlListItem)} must be contained within a {nameof(HtmlList)}");
        }
    }
}
