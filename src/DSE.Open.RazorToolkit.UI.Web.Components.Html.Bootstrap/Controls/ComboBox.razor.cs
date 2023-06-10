// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.Core;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

/// <summary>
/// Use a combo box (also known as a drop-down list) to present a list of items that a user can select from.
/// </summary>
public partial class ComboBox
{
    [Parameter]
    public required RenderFragment ChildContent { get; set; }

    private static int s_id;

    protected string InputId { get; } = "cb_" + s_id++.ToStringInvariant("X");
}
