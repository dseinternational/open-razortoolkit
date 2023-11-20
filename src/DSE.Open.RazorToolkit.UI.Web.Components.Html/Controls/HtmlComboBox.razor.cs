// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls;
public partial class HtmlComboBox
{
    [Parameter]
    public required RenderFragment ChildContent { get; set; }

    private static int s_id;

    protected string InputId { get; } = "tb_" + s_id++.ToStringInvariant("X");
}
