// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public class DisplayHeading : HtmlHeading
{
    public new DisplayHeadingLevel Level { get; set; }

    protected override string OuterElementName => "h1";

    // TODO: 
}
