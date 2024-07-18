// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

public class HtmlOptionGroup : HtmlContentElement
{
    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public required string Label { get; set; }

    protected override string OuterElementName => HtmlElements.OptionGroup;

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.Disabled, Disabled);
        builder.AddAttribute(++sequence, HtmlAttributes.Label, Label);

        return base.AddAttributes(++sequence, builder);
    }

    protected override void OnParametersSet()
    {
        ArgumentNullException.ThrowIfNull(Label);
        base.OnParametersSet();
    }
}
