// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using DSE.Open.RazorToolkit.UI.Abstractions;
using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

public class NavItemButton : Button
{
    public NavItemButton()
    {
        ButtonStyle = ButtonStyle.Link;
    }

    [CascadingParameter]
    public Nav? ParentNav { get; set; }

    [Parameter]
    public NavItemState State { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);

        classBuilder.Add(BootstrapClasses.NavLink);

        switch (State)
        {
            case NavItemState.Active:
                classBuilder.Add(BootstrapClasses.Active);
                break;
            case NavItemState.Disabled:
                classBuilder.Add(BootstrapClasses.Disabled);
                break;
            default:
            case NavItemState.Default:
                break;
        }
        base.BuildClasses(classBuilder);
    }
}
