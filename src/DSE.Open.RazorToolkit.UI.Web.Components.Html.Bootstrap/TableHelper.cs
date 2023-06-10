// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class BootstrapTableHelper
{
    public static string GetTableThemeClass(BootstrapTheme theme)
    {
        return theme switch
        {
            BootstrapTheme.Primary => BootstrapClasses.TablePrimary,
            BootstrapTheme.Secondary => BootstrapClasses.TableSecondary,
            BootstrapTheme.Success => BootstrapClasses.TableSuccess,
            BootstrapTheme.Danger => BootstrapClasses.TableDanger,
            BootstrapTheme.Warning => BootstrapClasses.TableWarning,
            BootstrapTheme.Info => BootstrapClasses.TableInfo,
            BootstrapTheme.Light => BootstrapClasses.TableLight,
            BootstrapTheme.Dark => BootstrapClasses.TableDark,
            _ => string.Empty
        };
    }

    public static string GetTableBorderClass(TableBorderStyle border)
    {
        return border switch
        {
            TableBorderStyle.Bordered => BootstrapClasses.TableBordered,
            TableBorderStyle.Borderless => BootstrapClasses.TableBorderless,
            _ => string.Empty
        };
    }
}
