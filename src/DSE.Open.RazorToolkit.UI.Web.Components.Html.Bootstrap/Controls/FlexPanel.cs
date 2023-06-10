// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

/// <summary>
/// A layout that can arrange its children horizontally and vertically in a stack,
/// and can also wrap its children if there are too many to fit in a single row or column.
/// </summary>
public class FlexPanel : FlexElementBase
{
    [Parameter]
    public bool Wrap { get; set; }

    [Parameter]
    public Orientation Orientation { get; set; }

    protected override void BuildFlexClasses(ClassBuilder classBuilder)
    {
        var reversedSuffix = FlexReversedSuffix;
        var breakpointSuffix = FlexBreakpointSuffix();

        if (Orientation is Orientation.Vertical)
        {
            classBuilder.Add(BootstrapClasses.FlexColumn);
            classBuilder.AddIfValueTrue(Reversed, BootstrapClasses.FlexColumnReverse);
        }
        else
        {
            classBuilder.AddIfValueTrue(Reversed, BootstrapClasses.FlexRowReverse);
        }

        if (Wrap)
        {
            classBuilder.Add($"flex-wrap{breakpointSuffix}{reversedSuffix}");
        }
    }

    protected override string OuterElementName => HtmlElements.Div;
}
