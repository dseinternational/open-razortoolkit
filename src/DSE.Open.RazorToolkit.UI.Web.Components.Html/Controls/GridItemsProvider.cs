// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls;

/// <summary>
/// A callback that provides data for a <see cref="HtmlDataGrid{TGridItem}"/>.
/// </summary>
/// <typeparam name="TGridItem">The type of data represented by each row in the grid.</typeparam>
/// <param name="request">Parameters describing the data being requested.</param>
/// <returns>A <see cref="ValueTask{GridItemsProviderResult{TResult}}" /> that gives the data to be displayed.</returns>
public delegate ValueTask<GridItemsProviderResult<TGridItem>> GridItemsProvider<TGridItem>(
    GridItemsProviderRequest<TGridItem> request);
