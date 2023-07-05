// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using DSE.Open.RazorToolkit.Core;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.Drawing;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class ModalTitle : Heading
{
    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        classBuilder.Add(BootstrapClasses.ModalTitle);
        base.BuildClasses(classBuilder);
    }
}
