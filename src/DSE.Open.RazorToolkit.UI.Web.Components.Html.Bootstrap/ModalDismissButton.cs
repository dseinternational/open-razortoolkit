// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class ModalDismissButton : Button
{
    /// <summary>
    /// Sets the class to btn-close, adding an X icon.
    /// If this is set, <see cref="Button.Size"/> and <see cref="Button.ButtonStyle"/> are ignored.
    /// </summary>
    [Parameter]
    public bool Close { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        if (Close)
        {
            classBuilder.Add(BootstrapClasses.ButtonClose);
            return; // A close button cannot have a style or size.
        }

        base.BuildClasses(classBuilder);
    }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, BootstrapDataAttributes.Toggle, BootstrapToggle.Modal.ToAttributeString());

        if (Close)
        {
            // A close button just displays an icon, so we need to add an aria-label for screen-readers.
            builder.AddAttribute(++sequence, "aria-label", "Close");
        }

        return base.AddAttributes(sequence, builder);
    }
}
