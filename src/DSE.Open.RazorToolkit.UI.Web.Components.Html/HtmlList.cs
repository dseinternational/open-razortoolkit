// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

/// <summary>
/// Contains a list of items.
/// </summary>
public class HtmlList : HtmlContentElement
{
    /// <summary>
    /// Gets or sets the format of the list.
    /// </summary>
    [Parameter]
    public ListFormat Format { get; set; }

    protected override string OuterElementName => Format switch
    {
        ListFormat.Unordered => HtmlElements.UnorderedList,
        ListFormat.Ordered => HtmlElements.OrderedList,
        _ => throw new InvalidOperationException($"Unsupported {nameof(ListFormat)} value.")
    };

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.CreateCascadingValue(0, 1, this, 2, base.BuildRenderTree);
    }
}
