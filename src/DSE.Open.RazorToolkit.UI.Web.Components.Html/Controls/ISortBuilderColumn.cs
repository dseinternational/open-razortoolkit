// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls;

/// <summary>
/// An interface that, if implemented by a <see cref="ColumnBase{TGridItem}"/> subclass, allows a <see cref="HtmlDataGrid{TGridItem}"/>
/// to understand the sorting rules associated with that column.
///
/// If a <see cref="ColumnBase{TGridItem}"/> subclass does not implement this, that column can still be marked as sortable and can
/// be the current sort column, but its sorting logic cannot be applied to the data queries automatically. The developer would be
/// responsible for implementing that sorting logic separately inside their <see cref="GridItemsProvider{TGridItem}"/>.
/// </summary>
/// <typeparam name="TGridItem">The type of data represented by each row in the grid.</typeparam>
public interface ISortBuilderColumn<TGridItem>
{
    /// <summary>
    /// Gets the sorting rules associated with the column.
    /// </summary>
    public GridSort<TGridItem>? SortBuilder { get; }
}
