// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.Core;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.Drawing;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlHeading : HtmlTextBlock
{
    [Parameter]
    public HeadingLevel Level { get; set; }

    public string LevelNumber => ((int)Level + 1).ToStringInvariant();

    protected override string OuterElementName => "h" + LevelNumber;
}
