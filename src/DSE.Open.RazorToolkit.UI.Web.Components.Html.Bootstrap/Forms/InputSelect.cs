// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Forms;

public class InputSelect<TValue> : HtmlInputSelect<TValue>
{
    [Parameter]
    public BootstrapSize SelectSize { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        Guard.IsNotNull(classBuilder);
        classBuilder.Add(BootstrapClasses.FormSelect);

        switch (SelectSize)
        {
            case BootstrapSize.Small:
                classBuilder.Add(BootstrapClasses.FormSelectSm);
                break;
            case BootstrapSize.Large:
                classBuilder.Add(BootstrapClasses.FormSelectLg);
                break;
        }

        base.BuildClasses(classBuilder);
    }
}
