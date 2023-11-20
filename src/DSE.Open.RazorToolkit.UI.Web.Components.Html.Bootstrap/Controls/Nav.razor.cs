// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

public partial class Nav
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public NavStyle NavStyle { get; set; }

    [Parameter]
    public NavLayout NavLayout { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        Guard.IsNotNull(classBuilder);

        classBuilder.Add(BootstrapClasses.Nav);

        switch (NavStyle)
        {
            case NavStyle.Tabs:
                classBuilder.Add(BootstrapClasses.NavTabs);
                break;
            case NavStyle.Pills:
                    classBuilder.Add(BootstrapClasses.NavPills);
                break;
            case NavStyle.Underline:
                classBuilder.Add(BootstrapClasses.NavUnderline);
                break;
            case NavStyle.None:
            default:
                break;
        }

        switch (NavLayout)
        {
            case NavLayout.Fill:
                classBuilder.Add(BootstrapClasses.NavFill);
                break;
            case NavLayout.Justify:
                classBuilder.Add(BootstrapClasses.NavJustified);
                break;
            case NavLayout.None:
            default:
                break;
        }

        base.BuildClasses(classBuilder);
    }
}
