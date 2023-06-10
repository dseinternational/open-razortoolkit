// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Numerics;
using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Charts.Components.Controls;

public partial class Chart<TValue>
    where TValue : INumber<TValue>
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public ChartOutputFormat OutputFormat { get; set; }

    [Parameter]
    public ChartData<TValue> Data { get; set; } = new();

    [Parameter]
    public IList<string> Labels { get; set; } = new List<string>();

    [Parameter]
    public ChartType ChartType { get; set; }
}
