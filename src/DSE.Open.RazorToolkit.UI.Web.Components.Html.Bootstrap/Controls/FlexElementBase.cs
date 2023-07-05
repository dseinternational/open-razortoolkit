// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.Drawing;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

public abstract class FlexElementBase : HtmlContentElement
{
    /// <summary>
    /// The breakpoint at which the element becomes a flex element.
    /// </summary>
    [Parameter]
    public Breakpoint FlexBreakpoint { get; set; }

    [Parameter]
    public bool Reversed { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        var flexClass = BreakpointHelper.AppendBreakpoint("d", FlexBreakpoint) + "-flex";
        classBuilder.Add(flexClass);

        BuildFlexClasses(classBuilder);

        base.BuildClasses(classBuilder);
    }

    protected abstract void BuildFlexClasses(ClassBuilder classBuilder);

    protected string FlexReversedSuffix => Reversed ? "-reverse" : string.Empty;

    protected string FlexBreakpointSuffix()
    {
        var breakpointClass = BreakpointHelper.GetBreakpointSuffix(FlexBreakpoint);

        if (!string.IsNullOrEmpty(breakpointClass))
        {
            breakpointClass = '-' + breakpointClass;
        }

        return breakpointClass;
    }
}
