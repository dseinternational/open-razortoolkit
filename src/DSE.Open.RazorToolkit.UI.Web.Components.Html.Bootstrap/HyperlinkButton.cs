// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class HyperlinkButton : HtmlHyperlink
{
    [Parameter]
    public ButtonStyle ButtonStyle { get; set; }

    [Parameter]
    public BootstrapSize Size { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);

        classBuilder.Add(BootstrapClasses.Button);
        classBuilder.Add(ButtonHelper.GetButtonThemeCss(ButtonStyle));
        classBuilder.Add(ButtonHelper.GetButtonSizeCss(Size));

        base.BuildClasses(classBuilder);
    }

    // Note: we do not need to override BuildAttributes(RenderTreeBuilder)
    // as the properties defined here are not bound to attributes - they
    // alter the CSS classes output via ComponentClass - which is already
    // among the attributes rendered by the base implementation.
}
