// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

public class CardImage : HtmlImage
{
    [CascadingParameter]
    public Card? ParentCard { get; set; }

    [Parameter]
    public CardImageLocation Location { get; set; } = CardImageLocation.Top;

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);
        switch (Location)
        {
            case CardImageLocation.Top:
                classBuilder.Add(BootstrapClasses.CardImageTop);
                break;
            case CardImageLocation.Bottom:
                classBuilder.Add(BootstrapClasses.CardImageBottom);
                break;
            case CardImageLocation.Overlay:
                classBuilder.Add(BootstrapClasses.CardImageOverlay);
                break;
        }

        base.BuildClasses(classBuilder);
    }
}
