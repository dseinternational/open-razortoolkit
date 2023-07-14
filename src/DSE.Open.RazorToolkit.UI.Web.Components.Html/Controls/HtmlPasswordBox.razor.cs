// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.Core;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.Drawing;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls;

public partial class HtmlPasswordBox : HtmlLabelledInputControl<string>
{
    private static int s_id;

    protected string InputId { get; } = "tb_" + s_id++.ToStringInvariant("X");

    /// <summary>
    /// Gets or sets the value that specifies the maximum number of characters allowed for user input.
    /// </summary>
    [Parameter]
    public int? MaxLength { get; set; }

    /// <summary>
    /// Gets or sets the value that specifies the minimum number of characters allowed for user input.
    /// </summary>
    [Parameter]
    public int? MinLength { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        classBuilder.Add("password-box");
        base.BuildClasses(classBuilder);
    }
}
