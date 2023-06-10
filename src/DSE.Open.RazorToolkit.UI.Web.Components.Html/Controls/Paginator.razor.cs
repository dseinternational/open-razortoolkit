// Copyright (c) Down Syndrome Education Enterprises CIC. All Rights Reserved.
// Information contained herein is PROPRIETARY AND CONFIDENTIAL.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls.Infrastructure;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls;

/// <summary>
/// A component that provides a user interface for <see cref="PaginationState"/>.
/// </summary>
public partial class Paginator : IDisposable
{
    private readonly EventCallbackSubscriber<PaginationState> _totalItemCountChanged;
    private bool _disposed;

    /// <summary>
    /// Specifies the associated <see cref="PaginationState"/>. This parameter is required.
    /// </summary>
    [Parameter, EditorRequired]
    public required PaginationState Value { get; set; }

    /// <summary>
    /// Optionally supplies a template for rendering the page count summary.
    /// </summary>
    [Parameter]
    public RenderFragment? SummaryTemplate { get; set; }

    /// <summary>
    /// Constructs an instance of <see cref="Paginator" />.
    /// </summary>
    public Paginator()
    {
        // The "total item count" handler doesn't need to do anything except cause this component to re-render
        _totalItemCountChanged = new EventCallbackSubscriber<PaginationState>(new EventCallback<PaginationState>(this, null));
    }

    private Task GoFirstAsync() => GoToPageAsync(0);

    private Task GoPreviousAsync() => GoToPageAsync(Value.CurrentPageIndex - 1);

    private Task GoNextAsync() => GoToPageAsync(Value.CurrentPageIndex + 1);

    private Task GoLastAsync() => GoToPageAsync(Value.LastPageIndex.GetValueOrDefault(0));

    private bool CanGoBack => Value.CurrentPageIndex > 0;

    private bool CanGoForwards => Value.CurrentPageIndex < Value.LastPageIndex;

    private Task GoToPageAsync(int pageIndex) => Value.SetCurrentPageIndexAsync(pageIndex);

    /// <inheritdoc />
    protected override void OnParametersSet() => _totalItemCountChanged.SubscribeOrMove(Value.TotalItemCountChangedSubscribable);

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _totalItemCountChanged.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
