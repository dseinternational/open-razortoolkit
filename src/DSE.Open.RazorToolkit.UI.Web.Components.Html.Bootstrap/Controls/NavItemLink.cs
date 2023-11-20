// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using DSE.Open.RazorToolkit.UI.Abstractions;
using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

// Named NavItemLink to avoid conflict with Microsoft.AspNetCore.Components.Routing.NavLink

public class NavItemLink : HtmlHyperlink
{
    [CascadingParameter]
    public Nav? ParentNav { get; set; }

    [Parameter]
    public NavItemLinkState State { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        classBuilder.Add(BootstrapClasses.NavLink);

        switch (State)
        {
            case NavItemLinkState.Active:
                classBuilder.Add(BootstrapClasses.Active);
                break;
            case NavItemLinkState.Disabled:
                classBuilder.Add(BootstrapClasses.Disabled);
                break;
            default:
            case NavItemLinkState.Default:
                break;
        }
        base.BuildClasses(classBuilder);
    }
}
