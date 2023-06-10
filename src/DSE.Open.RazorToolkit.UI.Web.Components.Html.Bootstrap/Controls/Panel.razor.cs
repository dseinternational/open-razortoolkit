// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

/// <summary>
/// A control that contains child content that can be styled.
/// </summary>
public partial class Panel
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
