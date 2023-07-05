// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Numerics;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.Drawing;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Forms;

public class InputRange<TValue> : HtmlInputRange<TValue> where TValue : IMinMaxValue<TValue>, INumber<TValue>
{
    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        classBuilder.Add(BootstrapClasses.FormRange);
        base.BuildClasses(classBuilder);
    }
}
