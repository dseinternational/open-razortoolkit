// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.Core;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls;
public partial class HtmlComboBox
{
    [Parameter]
    public required RenderFragment ChildContent { get; set; }

    private static int s_id;

    protected string InputId { get; } = "tb_" + s_id++.ToStringInvariant("X");
}
