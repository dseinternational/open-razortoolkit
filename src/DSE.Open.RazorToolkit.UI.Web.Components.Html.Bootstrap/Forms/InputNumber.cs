// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Numerics;
using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;
using System.Diagnostics.CodeAnalysis;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Forms;

public class InputNumber<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue>
    : HtmlInputNumber<TValue>,
      IFormControl
    where TValue : IMinMaxValue<TValue>, INumber<TValue>
{
    [Parameter]
    public BootstrapSize ControlSize { get; set; }

    [Parameter]
    public bool PlainText { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);
        classBuilder.AddFormControlClasses(this);
        base.BuildClasses(classBuilder);
    }
}
