// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

/// <summary>
/// A Bootstrap container. <see href="https://getbootstrap.com/docs/5.2/layout/containers/" />
/// </summary>
public class Container : HtmlBlock
{
    [Parameter]
    public ContainerType ContainerType { get; set; }

    private string ContainerClass => ContainerType switch
    {
        ContainerType.Default => BootstrapClasses.Container,
        ContainerType.Small => BootstrapClasses.ContainerSm,
        ContainerType.Medium => BootstrapClasses.ContainerMd,
        ContainerType.Large => BootstrapClasses.ContainerLg,
        ContainerType.Xl => BootstrapClasses.ContainerXl,
        ContainerType.Xxl => BootstrapClasses.ContainerXxl,
        ContainerType.Fluid => BootstrapClasses.ContainerFluid,
        _ => throw new ArgumentOutOfRangeException(nameof(ContainerType))
    };

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        Guard.IsNotNull(classBuilder);
        classBuilder.Add(ContainerClass);
        base.BuildClasses(classBuilder);
    }
}
