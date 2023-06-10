// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class PaginationLink : HtmlHyperlink
{
    [Parameter]
    public PaginationLinkType PaginationLinkType { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        classBuilder.Add(BootstrapClasses.PageLink);
        base.BuildClasses(classBuilder);
    }

    protected override int AddContent(int sequence, RenderTreeBuilder builder)
    {
        if (PaginationLinkType is PaginationLinkType.Default)
        {
            return base.AddContent(sequence, builder);
        }

        if (ChildContent is not null || !string.IsNullOrEmpty(Text))
        {
            return base.AddContent(sequence, builder);
        }

        sequence = PaginationLinkType switch
        {
            PaginationLinkType.Previous => BuildPaginationLink("Previous", "&laquo;", sequence, builder),
            PaginationLinkType.Next => BuildPaginationLink("Next", "&raquo;", sequence, builder),
            _ => sequence
        };

        return base.AddContent(sequence, builder);
    }

    private static int BuildPaginationLink(string label, string content, int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, "aria-label", label);
        builder.AddContent(++sequence, treeBuilder =>
        {
            var subSeq = 0;
            builder.OpenElement(++subSeq, HtmlElements.Span);
            builder.AddAttribute(++subSeq, "aria-hidden", "true");
            builder.AddMarkupContent(++subSeq, content);
            builder.CloseElement();
        });
        return sequence;
    }
}
