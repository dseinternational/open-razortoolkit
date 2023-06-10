// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.Core;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Controls;

/// <summary>
/// Presents a checkbox with a label.
/// </summary>
public partial class HtmlCheckBox
{
    private static int s_id;

    public string InputId { get; } = "cb_" + s_id++.ToStringInvariant("X");

    [Parameter]
    public RenderFragment? LabelContent { get; set; }

    [Parameter]
    public string? LabelText { get; set; }

    [Parameter]
    public bool IsReadOnly { get; set; }

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        classBuilder.Add("checkbox");
        base.BuildClasses(classBuilder);
    }
}
