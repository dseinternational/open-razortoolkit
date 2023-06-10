// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public static class BreakpointHelper
{
    public static string AppendBreakpoint(string value, Breakpoint breakpoint)
    {
        var suffix = GetBreakpointSuffix(breakpoint);

        if (!string.IsNullOrWhiteSpace(suffix))
        {
            return $"{value}-{suffix}";
        }

        return value;
    }

    public static string GetBreakpointSuffix(Breakpoint breakpoint)
    {
        return breakpoint switch
        {
            Breakpoint.Small => "sm",
            Breakpoint.Medium => "md",
            Breakpoint.Large => "lg",
            Breakpoint.ExtraLarge => "xl",
            Breakpoint.ExtraExtraLarge => "xxl",
            _ => string.Empty
        };
    }
}
