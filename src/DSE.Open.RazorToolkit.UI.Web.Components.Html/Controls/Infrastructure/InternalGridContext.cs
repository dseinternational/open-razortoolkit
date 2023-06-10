// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls.Infrastructure;

// The grid cascades this so that descendant columns can talk back to it. It's an internal type
// so that it doesn't show up by mistake in unrelated components.
internal class InternalGridContext<TGridItem>
{
    public HtmlDataGrid<TGridItem> HtmlDataGrid { get; }
    public EventCallbackSubscribable<object?> ColumnsFirstCollected { get; } = new();

    public InternalGridContext(HtmlDataGrid<TGridItem> htmlDataGrid)
    {
        HtmlDataGrid = htmlDataGrid;
    }
}
