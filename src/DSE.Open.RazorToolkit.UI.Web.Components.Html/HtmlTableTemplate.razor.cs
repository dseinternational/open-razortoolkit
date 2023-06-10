// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public partial class HtmlTableTemplate<TItem>
{
    [Parameter]
    public RenderFragment? TableHeader { get; set; }

    [Parameter]
    public RenderFragment? TableFooter { get; set; }

    [Parameter]
    public RenderFragment<TItem>? RowTemplate { get; set; }

    [Parameter, AllowNull]
    public IReadOnlyList<TItem> Items { get; set; }
}
