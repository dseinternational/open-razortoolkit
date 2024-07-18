// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class Table : HtmlTable
{
    [Parameter]
    public VerticalAlignmentOption VerticalAlignment { get; set; }

    [Parameter]
    public BootstrapTheme Theme { get; set; }

    [Parameter]
    public TableBorderStyle Borders { get; set; }

    [Parameter]
    public bool Small { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);
        classBuilder.Add(BootstrapClasses.Table);
        classBuilder.Add(BootstrapTableHelper.GetTableThemeClass(Theme));
        classBuilder.Add(BootstrapTableHelper.GetTableBorderClass(Borders));
        classBuilder.Add(VerticalAlignment.GetBootstrapClass());
        classBuilder.AddIfValueTrue(Small, BootstrapClasses.TableSm);
        base.BuildClasses(classBuilder);
    }
}
