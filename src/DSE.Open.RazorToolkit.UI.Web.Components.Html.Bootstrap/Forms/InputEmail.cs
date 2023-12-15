// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Forms;

public class InputEmail : HtmlInputEmail, IFormControl
{
    [Parameter]
    public BootstrapSize ControlSize { get; set; }

    [Parameter]
    public bool PlainText { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);
        classBuilder.AddFormControlClasses(this);
        base.BuildClasses(classBuilder);
    }
}
