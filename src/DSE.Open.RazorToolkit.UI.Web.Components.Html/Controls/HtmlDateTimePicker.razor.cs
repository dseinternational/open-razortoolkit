// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.Core;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.Drawing;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls;

public partial class HtmlDateTimePicker<TValue>
{
    private static int s_id;

    protected string InputId { get; } = "datepicker_" + s_id++.ToStringInvariant("X");

    /// <summary>
    /// Gets or sets the type of HTML input to be rendered.
    /// </summary>
    [Parameter]
    public HtmlInputDateType DateType { get; set; } = HtmlInputDateType.Date;

    /// <summary>
    /// Gets or sets the error message used when displaying an a parsing error.
    /// </summary>
    [Parameter]
    public string ParsingErrorMessage { get; set; } = string.Empty;

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        classBuilder.Add("datepicker");
        base.BuildClasses(classBuilder);
    }
}
