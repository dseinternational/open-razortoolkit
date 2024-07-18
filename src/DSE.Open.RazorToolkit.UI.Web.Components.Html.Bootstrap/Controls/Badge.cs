// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using DSE.Open.RazorToolkit.UI.Abstractions;
using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

public class Badge : HtmlSpan
{
    [Parameter]
    public bool RoundedPill { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);

        classBuilder.Add(BootstrapClasses.Badge);

        if (RoundedPill)
        {
            classBuilder.Add(BootstrapClasses.RoundedPill);
        }

        base.BuildClasses(classBuilder);
    }
}
