// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public partial class ListGroupTemplate<TItem>
{
    [Parameter]
    public ListGroupType Type { get; set; }

    [Parameter]
    public bool Flush { get; set; }

    [Parameter]
    public bool Numbered { get; set; }

    [Parameter]
    public bool Horizontal { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        Guard.IsNotNull(classBuilder);
        classBuilder.Add(BootstrapClasses.ListGroup);
        classBuilder.AddIfValueTrue(Flush, BootstrapClasses.ListGroupFlush);
        classBuilder.AddIfValueTrue(Numbered, BootstrapClasses.ListGroupNumbered);
        classBuilder.AddIfValueTrue(Horizontal, BootstrapClasses.ListGroupHorizontal);

        base.BuildClasses(classBuilder);
    }

    protected override void OnParametersSet()
    {
        if (ChildContent is not null)
        {
            throw new InvalidOperationException(
                $"{nameof(ChildContent)} is not supported in a {nameof(HtmlListTemplate<TItem>)}");
        }

        if (Flush && Horizontal)
        {
            // https://getbootstrap.com/docs/5.2/components/list-group/#horizontal
            throw new InvalidOperationException(
                "Currently horizontal list groups cannot be combined with flush list groups. ");
        }

        base.OnParametersSet();
    }
}
