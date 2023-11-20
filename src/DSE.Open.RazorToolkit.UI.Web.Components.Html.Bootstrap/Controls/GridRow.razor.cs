// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

public partial class GridRow
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public RowColumns RowColumns { get; set; }

    [Parameter]
    public RowColumns RowColumnsSm { get; set; }

    [Parameter]
    public RowColumns RowColumnsMd { get; set; }

    [Parameter]
    public RowColumns RowColumnsLg { get; set; }

    [Parameter]
    public RowColumns RowColumnsXl { get; set; }

    [Parameter]
    public RowColumns RowColumnsXxl { get; set; }


    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        var classes = new List<string>
        {
            BootstrapClasses.Row,
            ColumnClass(Breakpoint.ExtraSmall, RowColumns),
            ColumnClass(Breakpoint.Small, RowColumnsSm),
            ColumnClass(Breakpoint.Medium, RowColumnsMd),
            ColumnClass(Breakpoint.Large, RowColumnsLg),
            ColumnClass(Breakpoint.ExtraLarge, RowColumnsXl),
            ColumnClass(Breakpoint.ExtraExtraLarge, RowColumnsXxl)
        };

        foreach (var className in classes.Distinct())
        {
            classBuilder.Add(className);
        }

        base.BuildClasses(classBuilder);
    }

    private static string ColumnClass(Breakpoint breakpoint, RowColumns rowColumns)
    {
        if (rowColumns is RowColumns.None)
        {
            return string.Empty;
        }

        var classBase = BreakpointHelper.AppendBreakpoint("row-cols", breakpoint);

        var spanSuffix = rowColumns switch
        {
            RowColumns.Rows1 => "1",
            RowColumns.Rows2 => "2",
            RowColumns.Rows3 => "3",
            RowColumns.Rows4 => "4",
            RowColumns.Rows5 => "5",
            RowColumns.Rows6 => "6",
            RowColumns.Rows7 => "7",
            RowColumns.Rows8 => "8",
            RowColumns.Rows9 => "9",
            RowColumns.Rows10 => "10",
            RowColumns.Rows11 => "11",
            RowColumns.Rows12 => "12",
            RowColumns.RowsAuto => "auto",
            _ => throw new ArgumentOutOfRangeException(nameof(rowColumns), rowColumns, null)
        };

        return $"{classBase}-{spanSuffix}";
    }
}
