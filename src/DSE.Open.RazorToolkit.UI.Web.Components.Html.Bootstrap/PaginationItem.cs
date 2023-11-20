// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

/// <summary>
/// Item in a pagination component
/// </summary>
/// <remarks>
/// <see href="https://getbootstrap.com/docs/5.2/components/pagination/" />
/// </remarks>
public class PaginationItem : HtmlListItem
{
    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool Active { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        classBuilder.Add(BootstrapClasses.PageItem);

        classBuilder.AddIfValueTrue(Disabled, BootstrapClasses.Disabled);
        classBuilder.AddIfValueTrue(Active, BootstrapClasses.Active);

        base.BuildClasses(classBuilder);
    }
}
