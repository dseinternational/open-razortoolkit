// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Numerics;
using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls;

public partial class HtmlNumberBox<TValue>: HtmlLabelledInputNumericControl<TValue>
    where TValue : INumber<TValue>, IMinMaxValue<TValue>
{
    private static int s_id;

    protected string InputId { get; } = "nb_" + s_id++.ToStringInvariant("X");

    /// <summary>
    /// Gets or sets the error message used when displaying an a parsing error.
    /// </summary>
    [Parameter]
    public string ParsingErrorMessage { get; set; } = string.Empty;

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        Guard.IsNotNull(classBuilder);
        classBuilder.Add("number-box");
        base.BuildClasses(classBuilder);
    }
}
