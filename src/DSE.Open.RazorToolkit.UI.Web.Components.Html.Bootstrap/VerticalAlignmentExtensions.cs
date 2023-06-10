// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public static class VerticalAlignmentExtensions
{
    public static string GetBootstrapClass(this VerticalAlignmentOption option)
    {
        return option switch
        {
            VerticalAlignmentOption.Middle => BootstrapClasses.AlignMiddle,
            VerticalAlignmentOption.Top => BootstrapClasses.AlignTop,
            VerticalAlignmentOption.Bottom => BootstrapClasses.AlignBottom,
            _ => string.Empty
        };
    }
}
