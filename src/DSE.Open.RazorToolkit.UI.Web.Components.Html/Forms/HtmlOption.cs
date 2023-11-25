// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;
using System.Diagnostics.CodeAnalysis;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

public class HtmlOption<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : HtmlContentElement
{
    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public TValue? Value { get; set; }

    [Parameter]
    public bool Selected { get; set; }

    [Parameter]
    public string? Label { get; set; }

    protected override string OuterElementName => HtmlElements.Option;

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.Disabled, Disabled);
        builder.AddAttribute(++sequence, HtmlAttributes.Value, BindConverter.FormatValue(Value)?.ToString());
        builder.AddAttribute(++sequence, HtmlAttributes.Selected, Selected);
        builder.AddAttribute(++sequence, HtmlAttributes.Label, Label);

        return base.AddAttributes(++sequence, builder);
    }

    protected override void OnParametersSet()
    {
        if (Label is null && ChildContent is null)
        {
            throw new ArgumentNullException($"HtmlOption requires either {nameof(ChildContent)} or a {nameof(Label)}");
        }

        base.OnParametersSet();
    }
}
