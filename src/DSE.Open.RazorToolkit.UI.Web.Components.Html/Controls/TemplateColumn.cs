// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls;

/// <summary>
/// Represents a <see cref="HtmlDataGrid{TGridItem}"/> column whose cells render a supplied template.
/// </summary>
/// <typeparam name="TGridItem">The type of data represented by each row in the grid.</typeparam>
public class TemplateColumn<TGridItem> : ColumnBase<TGridItem>, ISortBuilderColumn<TGridItem>
{
    private static readonly RenderFragment<TGridItem> s_emptyChildContent = _ => _ => { };

    /// <summary>
    /// Specifies the content to be rendered for each row in the table.
    /// </summary>
    [Parameter]
    public RenderFragment<TGridItem> ChildContent { get; set; } = s_emptyChildContent;

    /// <summary>
    /// Optionally specifies sorting rules for this column.
    /// </summary>
    [Parameter]
    public GridSort<TGridItem>? SortBy { get; set; }

    GridSort<TGridItem>? ISortBuilderColumn<TGridItem>.SortBuilder => SortBy;

    /// <inheritdoc />
    protected internal override void CellContent(RenderTreeBuilder builder, TGridItem item)
    {
        builder.AddContent(0, ChildContent(item));
    }

    /// <inheritdoc />
    protected override bool IsSortableByDefault()
    {
        return SortBy is not null;
    }
}
