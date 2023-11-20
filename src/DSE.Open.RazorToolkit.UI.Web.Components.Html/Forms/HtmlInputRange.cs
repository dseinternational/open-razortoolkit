// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Numerics;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

public class HtmlInputRange<TValue>: HtmlInputNumeric<TValue> where TValue : IMinMaxValue<TValue>, INumber<TValue>
{
    public override HtmlInputType? InputType => HtmlInputType.Range;
}
