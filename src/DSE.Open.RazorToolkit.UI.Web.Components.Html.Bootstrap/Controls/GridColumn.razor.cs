// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

public partial class GridColumn
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public ColumnSpan ColumnSpan { get; set; }

    [Parameter]
    public ColumnSpan ColumnSpanSm { get; set; }

    [Parameter]
    public ColumnSpan ColumnSpanMd { get; set; }

    [Parameter]
    public ColumnSpan ColumnSpanLg { get; set; }

    [Parameter]
    public ColumnSpan ColumnSpanXl { get; set; }

    [Parameter]
    public ColumnSpan ColumnSpanXxl { get; set; }


    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        var classes = new List<string>
        {
            ColumnClass(Breakpoint.ExtraSmall, ColumnSpan),
            ColumnClass(Breakpoint.Small, ColumnSpanSm),
            ColumnClass(Breakpoint.Medium, ColumnSpanMd),
            ColumnClass(Breakpoint.Large, ColumnSpanLg),
            ColumnClass(Breakpoint.ExtraLarge, ColumnSpanXl),
            ColumnClass(Breakpoint.ExtraExtraLarge, ColumnSpanXxl)
        };

        foreach (var className in classes.Distinct())
        {
            classBuilder.Add(className);
        }

        base.BuildClasses(classBuilder);
    }

    private static string ColumnClass(Breakpoint breakpoint, ColumnSpan columnSpan)
    {
        if (columnSpan is ColumnSpan.None)
        {
            return string.Empty;
        }

        var classBase = BreakpointHelper.AppendBreakpoint("col", breakpoint);

        if (columnSpan is ColumnSpan.Fill)
        {
            return classBase;
        }

        var spanSuffix = columnSpan switch
        {
            ColumnSpan.Span1 => "1",
            ColumnSpan.Span2 => "2",
            ColumnSpan.Span3 => "3",
            ColumnSpan.Span4 => "4",
            ColumnSpan.Span5 => "5",
            ColumnSpan.Span6 => "6",
            ColumnSpan.Span7 => "7",
            ColumnSpan.Span8 => "8",
            ColumnSpan.Span9 => "9",
            ColumnSpan.Span10 => "10",
            ColumnSpan.Span11 => "11",
            ColumnSpan.Span12 => "12",
            ColumnSpan.Auto => "auto",
            _ => throw new ArgumentOutOfRangeException(nameof(columnSpan), columnSpan, null)
        };

        return $"{classBase}-{spanSuffix}";
    }

    private static bool IsResponsiveColumnClass(string className)
    {
        return className is BootstrapClasses.ColSm or BootstrapClasses.ColMd or BootstrapClasses.ColLg or BootstrapClasses.ColXl or BootstrapClasses.ColXxl;
    }
}
