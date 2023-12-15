// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

public class CardBody : HtmlBlock
{
    [CascadingParameter]
    public Card? ParentCard { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);
        classBuilder.Add(BootstrapClasses.CardBody);
        base.BuildClasses(classBuilder);
    }
}
