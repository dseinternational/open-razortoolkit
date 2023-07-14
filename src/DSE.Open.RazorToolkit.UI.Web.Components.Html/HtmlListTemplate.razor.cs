// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

/// <summary>
/// Renders a list of items using a template.
/// </summary>
public partial class HtmlListTemplate<TItem> : HtmlList
{
    [Parameter]
    public RenderFragment<TItem>? ItemTemplate { get; set; }

    [Parameter, AllowNull]
    public IReadOnlyList<TItem> Items { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (ChildContent is not null)
        {
            throw new InvalidOperationException(
                $"{nameof(ChildContent)} is not supported in a {nameof(HtmlListTemplate<TItem>)}");
        }
    }
}
