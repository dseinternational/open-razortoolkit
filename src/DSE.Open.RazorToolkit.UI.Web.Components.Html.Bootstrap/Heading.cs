// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class Heading : HtmlHeading
{
    [Parameter]
    public BackgroundColor BackgroundColor { get; set; }

    [Parameter]
    public TextColor TextColor { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        classBuilder.ApplyBackgroundColor(BackgroundColor);
        base.BuildClasses(classBuilder);
    }
}
