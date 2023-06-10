// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public static class ButtonHelper
{
    public static string GetButtonThemeCss(ButtonStyle style)
    {
        return style switch
        {
            ButtonStyle.None => string.Empty,
            ButtonStyle.Primary => BootstrapClasses.ButtonPrimary,
            ButtonStyle.Secondary => BootstrapClasses.ButtonSecondary,
            ButtonStyle.Success => BootstrapClasses.ButtonSuccess,
            ButtonStyle.Warning => BootstrapClasses.ButtonWarning,
            ButtonStyle.Danger => BootstrapClasses.ButtonDanger,
            ButtonStyle.Info => BootstrapClasses.ButtonInfo,
            ButtonStyle.Light => BootstrapClasses.ButtonLight,
            ButtonStyle.Dark => BootstrapClasses.ButtonDark,
            ButtonStyle.Link => BootstrapClasses.ButtonLink,
            ButtonStyle.OutlinePrimary => BootstrapClasses.ButtonOutlinePrimary,
            ButtonStyle.OutlineSecondary => BootstrapClasses.ButtonOutlineSecondary,
            ButtonStyle.OutlineSuccess => BootstrapClasses.ButtonOutlineSuccess,
            ButtonStyle.OutlineWarning => BootstrapClasses.ButtonOutlineWarning,
            ButtonStyle.OutlineDanger => BootstrapClasses.ButtonOutlineDanger,
            ButtonStyle.OutlineInfo => BootstrapClasses.ButtonOutlineInfo,
            ButtonStyle.OutlineLight => BootstrapClasses.ButtonOutlineLight,
            ButtonStyle.OutlineDark => BootstrapClasses.ButtonOutlineDark,
            _ => throw new ArgumentOutOfRangeException(nameof(style), style, null)
        };
    }

    public static string GetButtonSizeCss(BootstrapSize size)
    {
        return size switch
        {
            BootstrapSize.Large => BootstrapClasses.ButtonLg,
            BootstrapSize.Small => BootstrapClasses.ButtonSm,
            BootstrapSize.Default => string.Empty,
            _ => throw new ArgumentOutOfRangeException(nameof(size))
        };
    }
}
