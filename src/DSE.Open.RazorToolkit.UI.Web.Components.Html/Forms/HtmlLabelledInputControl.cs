// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

public class HtmlLabelledInputControl<TValue> : HtmlInputControl<TValue>
{
    /// <summary>
    /// Gets or sets the content for the control's header. Typically, this provides
    /// additional context, beyond the <see cref="Header"/>.
    /// </summary>
    [Parameter]
    public RenderFragment? Description { get; set; }

    [Parameter]
    public string? DescriptionText { get; set; }

    /// <summary>
    /// Gets or sets the content for the control's header. Typically, this labels the
    /// text input. If this is set, then the it take precedence over <see cref="HeaderText"/>.
    /// </summary>
    [Parameter]
    public RenderFragment? Header { get; set; }

    /// <summary>
    /// Gets or sets the text for the control's header. If set and if <see cref="Header"/> is
    /// <see langword="null"/>, then this is rendered in a <see cref="HtmlLabel"/>.
    /// </summary>
    [Parameter]
    public string? HeaderText { get; set; }

    [Parameter]
    public Expression<Func<TValue>>? ValidationFor { get; set; }
}
