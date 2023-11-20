// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class ModalDialog : HtmlBlock
{
    /// <summary>
    /// Allows the modal body to scroll.
    /// </summary>
    [Parameter]
    public bool Scrollable { get; set; }

    /// <summary>
    /// Vertically centers the modal.
    /// </summary>
    [Parameter]
    public bool Centered { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        Guard.IsNotNull(classBuilder);
        classBuilder.Add(BootstrapClasses.ModalDialog);

        if (Scrollable)
        {
            classBuilder.Add(BootstrapClasses.ModalDialogScrollable);
        }

        if (Centered)
        {
            classBuilder.Add(BootstrapClasses.ModalDialogCentered);
        }

        base.BuildClasses(classBuilder);
    }
}
