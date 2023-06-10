// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public static class BootstrapToggleExtensions
{
    public static string ToAttributeString(this BootstrapToggle toggle)
    {
        return toggle switch
        {
            BootstrapToggle.Collapse => "collapse",
            BootstrapToggle.Modal => "modal",
            BootstrapToggle.Button => "button",
            BootstrapToggle.Dropdown => "dropdown",
            BootstrapToggle.Offcanvas => "offcanvas",
            BootstrapToggle.Tab => "tab",
            BootstrapToggle.Pill => "pill",
            BootstrapToggle.List => "list",
            _ => throw new ArgumentOutOfRangeException(nameof(toggle), toggle, null)
        };
    }
}
