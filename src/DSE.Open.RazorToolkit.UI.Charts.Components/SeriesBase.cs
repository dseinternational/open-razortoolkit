// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Numerics;
using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Charts.Components.Controls;
using DSE.Open.RazorToolkit.UI.Core;

namespace DSE.Open.RazorToolkit.UI.Charts.Components;

/// <summary>
/// Base implementation of a component that renders a data series.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public abstract class SeriesBase<TValue> : ViewComponent, IDisposable
    where TValue : INumber<TValue>
{
    private readonly DataSeries<TValue> _data = new();
    private bool _disposed;

    [CascadingParameter]
    public Chart<TValue>? ParentChart { get; set; }

    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the data values associated with the series.
    /// </summary>
    [Parameter] public IList<TValue> Values { get; set; } = new List<TValue>();

    protected override void OnParametersSet()
    {
        _data.Name = Name;
        _data.Values = Values;
    }

    protected override void OnInitialized()
    {
        ParentChart?.Data.Series.Add(_data);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                ParentChart?.Data.Series.Remove(_data);
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
