// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlTableHeaderCell : HtmlContentElement
{
    protected override string OuterElementName => HtmlElements.TableHeaderCell;

    [CascadingParameter]
    public required HtmlTableRow ParentRow { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.CreateCascadingValue(0, 1, this, 2, base.BuildRenderTree);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (ParentRow is null)
        {
            throw new InvalidOperationException($"{nameof(HtmlTableHeaderCell)} must be contained within a {nameof(HtmlTableRow)}");
        }
    }
}
