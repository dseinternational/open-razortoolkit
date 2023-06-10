// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlTableHeader : HtmlContentElement
{
    protected override string OuterElementName => HtmlElements.TableHeader;

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
            throw new InvalidOperationException($"{nameof(HtmlTableHeader)} must be contained within a {nameof(HtmlTable)}");
        }
    }
}
public class HtmlTableRow : HtmlContentElement
{
    protected override string OuterElementName => "tr";

    [CascadingParameter]
    public required HtmlTable ParentTable { get; set; }

    /// <summary>
    /// Gets a reference to the table header containing the row, if the row is
    /// contained within a header section, otherwise returns <see langword="null"/>.
    /// </summary>
    [CascadingParameter]
    public HtmlTableHeader? ParentHeader { get; set; }

    /// <summary>
    /// Gets a reference to the table body containing the row, if the row is
    /// contained within a body section, otherwise returns <see langword="null"/>.
    /// </summary>
    [CascadingParameter]
    public HtmlTableBody? ParentBody { get; set; }

    /// <summary>
    /// Gets a reference to the table footer containing the row, if the row is
    /// contained within a footer section, otherwise returns <see langword="null"/>.
    /// </summary>
    [CascadingParameter]
    public HtmlTableFooter? ParentFooter { get; set; }

    public bool IsInHeader => ParentHeader is not null;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.CreateCascadingValue(0, 1, this, 2, base.BuildRenderTree);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (ParentTable is null)
        {
            throw new InvalidOperationException($"{nameof(HtmlTableRow)} must be contained within a {nameof(HtmlTable)}");
        }

        if (ParentBody is null)
        {
            return;
        }

        if (ParentHeader is not null || ParentFooter is not null)
        {
            throw new InvalidOperationException($"{nameof(HtmlTableRow)} must only be contained within one of a body, header or footer.");
        }
    }
}
