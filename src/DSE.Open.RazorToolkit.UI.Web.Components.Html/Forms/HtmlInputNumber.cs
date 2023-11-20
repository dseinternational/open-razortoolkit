// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

public class HtmlInputNumber<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : HtmlInputNumeric<TValue> where TValue : INumber<TValue>, IMinMaxValue<TValue>
{
    public override HtmlInputType? InputType => HtmlInputType.Number;

    [Parameter]
    public string? PlaceholderText { get; set; }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.Placeholder, PlaceholderText);

        return base.AddAttributes(sequence, builder);
    }
}
