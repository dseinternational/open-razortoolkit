// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

public class HtmlInputUrl: HtmlInputText
{
    protected HtmlInputUrl()
    {
        AutoCapitalize = AutoCapitalize.None;
    }

    public override HtmlInputType? InputType => HtmlInputType.Url;
}
