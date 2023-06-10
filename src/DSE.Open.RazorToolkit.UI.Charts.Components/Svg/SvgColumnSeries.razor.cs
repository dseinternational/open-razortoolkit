// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Numerics;
using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Charts.Components.Svg;

public partial class SvgColumnSeries<TValue>
    where TValue : INumber<TValue>
{
    [CascadingParameter]
    public SvgChartArea<TValue>? ParentChartArea { get; set; }

}
