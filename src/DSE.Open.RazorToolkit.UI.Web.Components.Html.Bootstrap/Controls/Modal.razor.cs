// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

public partial class Modal
{
    /// <summary>
    /// Adds an animation so the modal fades in and out of view.
    /// </summary>
    [Parameter]
    public bool Fade { get; set; }

    [Parameter, DisallowNull]
    public required string Id { get; set; }

    [Parameter]
    public required RenderFragment ChildContent { get; set; }

    protected override void OnParametersSet()
    {
        Guard.IsNotNullOrEmpty(Id);
        base.OnParametersSet();
    }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        classBuilder.Add(BootstrapClasses.Modal);

        if (Fade)
        {
            classBuilder.Add(BootstrapClasses.Fade);
        }

        base.BuildClasses(classBuilder);
    }
}
