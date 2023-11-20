// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class Label : HtmlLabel
{
    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        classBuilder.Add(BootstrapClasses.FormLabel);
        base.BuildClasses(classBuilder);
    }
}
