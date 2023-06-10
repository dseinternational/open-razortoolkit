// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components.Forms;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

/// <summary>
/// Represents the type of HTML input to be rendered by a <see cref="InputDate{TValue}"/> component.
/// </summary>
public enum HtmlInputDateType
{
    /// <summary>
    /// Lets the user enter a date.
    /// </summary>
    Date,

    /// <summary>
    /// Lets the user enter both a date and a time.
    /// </summary>
    DateTimeLocal,

    /// <summary>
    /// Lets the user enter a month and a year.
    /// </summary>
    Month,

    /// <summary>
    /// Lets the user enter a time.
    /// </summary>
    Time
}
