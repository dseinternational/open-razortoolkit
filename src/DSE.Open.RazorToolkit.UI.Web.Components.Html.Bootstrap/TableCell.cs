// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class TableCell : HtmlTableCell
{
    [Parameter]
    public VerticalAlignmentOption VerticalAlignment { get; set; }

    [Parameter]
    public BootstrapTheme Theme { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        Guard.IsNotNull(classBuilder);
        classBuilder.Add(BootstrapTableHelper.GetTableThemeClass(Theme));
        classBuilder.Add(VerticalAlignment.GetBootstrapClass());
        base.BuildClasses(classBuilder);
    }
}
