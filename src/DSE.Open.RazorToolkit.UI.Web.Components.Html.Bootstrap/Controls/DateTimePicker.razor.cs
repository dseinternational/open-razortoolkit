// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Forms;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

public partial class DateTimePicker<TValue> : IFormControl
{
    [Parameter]
    public BootstrapSize ControlSize { get; set; }

    [Parameter]
    public bool PlainText { get; set; }

    /// <summary>
    /// Adds a <see cref="BootstrapClasses.WidthAuto"/> class to the control so it shrinks to fit its content.
    /// </summary>
    [Parameter]
    public bool AutoWidth { get; set; } = true;

    private string InputClass => AutoWidth ? $"datepicker-input {BootstrapClasses.WidthAuto}" : "datepicker-input";
}
