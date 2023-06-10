// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls;

/// <summary>
/// Describes the direction in which a <see cref="HtmlDataGrid{TGridItem}"/> column is sorted.
/// </summary>
public enum SortDirection
{
    /// <summary>
    /// Ascending order.
    /// </summary>
    Ascending,

    /// <summary>
    /// Descending order.
    /// </summary>
    Descending,

    /// <summary>
    /// Automatic sort order. When used with <see cref="HtmlDataGrid{TGridItem}.SortByColumnAsync(ColumnBase{TGridItem}, SortDirection)"/>,
    /// the sort order will automatically toggle between <see cref="Ascending"/> and <see cref="Descending"/> on successive calls, and
    /// resets to <see cref="Ascending"/> whenever the specified column is changed.
    /// </summary>
    Auto,
}
