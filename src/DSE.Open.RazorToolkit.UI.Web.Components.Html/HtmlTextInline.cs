// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

/// <summary>
/// A component that primarily renders text content. Provides a <see cref="Text"/>
/// property, which, if not <see langword="null"/>, overrides any specified child content.
/// </summary>
public class HtmlTextInline : HtmlInline, ITextView
{
    /// <summary>
    /// Gets or sets the text displayed by the component. If <see cref="Text"/> is
    /// not <see langword="null"/>, then the value is displayed in place of any
    /// specified <see cref="HtmlContentElement.ChildContent"/>.
    /// </summary>
    [Parameter]
    public string? Text { get; set; }

    protected override int AddContent(int sequence, RenderTreeBuilder builder)
    {
        if (Text is not null)
        {
            builder.AddContent(sequence, Text);
        }
        else
        {
            builder.AddContent(sequence, ChildContent);
        }
        return sequence + 1;
    }
}
