// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlTableBody : HtmlContentElement
{
    protected override string OuterElementName => HtmlElements.TableBody;

    [CascadingParameter]
    public required HtmlTable ParentTable { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.CreateCascadingValue(0, 1, this, 2, base.BuildRenderTree);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (ParentTable is null)
        {
            throw new InvalidOperationException($"{nameof(HtmlTableBody)} must be contained within a {nameof(HtmlTable)}");
        }
    }
}
