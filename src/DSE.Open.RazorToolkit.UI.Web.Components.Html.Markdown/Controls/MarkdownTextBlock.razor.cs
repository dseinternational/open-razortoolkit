// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Markdig;
using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Markdown.Controls;

/// <summary>
/// Renders Markdown, does not support ChildContent.
/// </summary>
public partial class MarkdownTextBlock
{
    private static readonly MarkdownPipeline s_pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

    [Parameter]
    public string? Content { get; set; }

    protected virtual string GetContentRendered()
    {
        if (Content is null)
        {
            return string.Empty;
        }

        // TODO: Consider options we might support

        return Markdig.Markdown.ToHtml(Content, s_pipeline);
    }
}
