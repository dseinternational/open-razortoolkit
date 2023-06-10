// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

/// <summary>
/// Base class for a component that wraps one or more input components (elements).
/// </summary>
/// <typeparam name="TValue"></typeparam>
public abstract class HtmlInputComponent<TValue> : WebComponent
{
    /// <summary>
    /// Gets or sets the value of the input. This should be used with two-way binding.
    /// </summary>
    /// <example>
    /// @bind-Value="model.PropertyName"
    /// </example>
    [Parameter]
    public TValue? Value { get; set; }

    /// <summary>
    /// Gets or sets a callback that updates the bound value.
    /// </summary>
    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets an expression that identifies the bound value.
    /// </summary>
    [Parameter]
    public Expression<Func<TValue>>? ValueExpression { get; set; }

}
