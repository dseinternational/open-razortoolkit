// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

public abstract class HtmlTextInputElement : HtmlInputElement<string>
{
    [Parameter]
    public string? Placeholder { get; set; }

    [Parameter]
    public int? MinLength { get; set; }

    [Parameter]
    public int? MaxLength { get; set; }

    [Parameter]
    public bool SpellCheck { get; set; }

    [Parameter]
    public AutoCapitalize AutoCapitalize { get; set; }
}
