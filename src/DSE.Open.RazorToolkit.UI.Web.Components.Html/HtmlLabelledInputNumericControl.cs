// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Numerics;
using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public abstract class HtmlLabelledInputNumericControl<TValue> : HtmlLabelledInputControl<TValue> where TValue : INumber<TValue>, IMinMaxValue<TValue>
{
    private static readonly TValue? s_defaultStep = (TValue?)NumericInputHelper.GetDefaultStep<TValue>();

    [Parameter]
    public virtual TValue? Minimum { get; set; } = TValue.MinValue;

    [Parameter]
    public virtual TValue? Maximum { get; set; } = TValue.MaxValue;

    [Parameter]
    public TValue? Step { get; set; } = s_defaultStep;
}
