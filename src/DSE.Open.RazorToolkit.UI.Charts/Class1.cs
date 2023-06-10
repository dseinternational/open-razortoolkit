// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Numerics;

namespace DSE.Open.RazorToolkit.UI.Charts;

public class DataSeries<T>
    where T : INumber<T>
{
    public string? Name { get; set; }

    public IList<T> Values { get; set; } = new List<T>();
}

public class ChartData<T>
    where T : INumber<T>
{
    public IList<string> Labels { get; set; } = new List<string>();

    public IList<DataSeries<T>> Series { get; set; } = new List<DataSeries<T>>();
}
