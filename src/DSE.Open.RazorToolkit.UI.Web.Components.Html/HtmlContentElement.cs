// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

/// <summary>
/// A <see cref="HtmlElement"/> that renders a <i>single</i> standard HTML element
/// that supports child content.
/// </summary>
public abstract class HtmlContentElement : HtmlElement
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override int AddContent(int sequence, RenderTreeBuilder builder)
    {
        builder.AddContent(++sequence, ChildContent);
        return ++sequence;
    }
}

/// <summary>
/// A <see cref="HtmlElement"/> that renders a <i>single</i> standard HTML element
/// that supports child content.
/// </summary>
public abstract class HtmlContentElement<TContent> : HtmlElement
{
    [Parameter]
    public RenderFragment<TContent>? ChildContent { get; set; }

    /// <summary>
    /// Provides data for the <see cref="ChildContent"/>. If <see langword="null"/>, then
    /// <see cref="ChildContent"/> is not rendered.
    /// </summary>
    public TContent? ContentModel { get; set; }

    protected override int AddContent(int sequence, RenderTreeBuilder builder)
    {
        ++sequence; // increment outside if

        if (ContentModel is not null)
        {
            builder.AddContent(sequence, ChildContent?.Invoke(ContentModel));
        }

        return ++sequence;
    }
}
