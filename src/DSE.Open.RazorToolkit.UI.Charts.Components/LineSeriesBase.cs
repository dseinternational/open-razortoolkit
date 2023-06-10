// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Numerics;

namespace DSE.Open.RazorToolkit.UI.Charts.Components;

// TODO:
//
// - Series<T> ? numeric types?
// - LineSeries
// - ColumnSeries
// - AreaSeries
// - ScatterSeries

// - SvgLineSeries
// - SvgColumnSeries
// - SvgAreaSeries
// - SvgScatterSeries

public abstract class LineSeriesBase<TValue> : SeriesBase<TValue>
    where TValue : INumber<TValue>
{
}
