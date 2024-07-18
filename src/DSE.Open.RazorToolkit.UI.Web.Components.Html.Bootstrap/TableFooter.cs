// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class TableFooter : HtmlTableFooter
{
    [Parameter]
    public bool Dividers { get; set; }

    [Parameter]
    public BootstrapTheme Theme { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);
        classBuilder.Add(BootstrapTableHelper.GetTableThemeClass(Theme));
        classBuilder.AddIfValueTrue(Dividers, BootstrapClasses.TableGroupDivider);
        base.BuildClasses(classBuilder);
    }
}
