// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Forms;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

/// <summary>
///
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item><see href="https://getbootstrap.com/docs/5.2/forms/form-control/" /></item>
/// </list>
/// </remarks>
public partial class TextBox : IFormControl
{
    [Parameter]
    public BootstrapSize ControlSize { get; set; }

    [Parameter]
    public bool PlainText { get; set; }
}
