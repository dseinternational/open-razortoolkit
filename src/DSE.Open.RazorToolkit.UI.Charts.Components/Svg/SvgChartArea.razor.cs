// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Numerics;
using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Charts.Components.Controls;

namespace DSE.Open.RazorToolkit.UI.Charts.Components.Svg;

public partial class SvgChartArea<TValue>
    where TValue : INumber<TValue>
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [CascadingParameter]
    public Chart<TValue>? ParentChart { get; set; }

}
