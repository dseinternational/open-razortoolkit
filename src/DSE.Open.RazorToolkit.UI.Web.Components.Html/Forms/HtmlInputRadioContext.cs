// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

/// <summary>
/// Describes context for an <see cref="HtmlInputRadio{TValue}"/> component.
/// </summary>
internal sealed class HtmlInputRadioContext
{
    public HtmlInputRadioContext? ParentContext { get; }
    public EventCallback<ChangeEventArgs> ChangeEventCallback { get; }

    // Mutable properties that may change any time an InputRadioGroup is rendered
    public string? GroupName { get; set; }
    public object? CurrentValue { get; set; }
    public string? FieldClass { get; set; }

    /// <summary>
    /// Instantiates a new <see cref="HtmlInputRadioContext" />.
    /// </summary>
    /// <param name="parentContext">The parent context, if any.</param>
    /// <param name="changeEventCallback">The event callback to be invoked when the selected value is changed.</param>
    public HtmlInputRadioContext(HtmlInputRadioContext? parentContext, EventCallback<ChangeEventArgs> changeEventCallback)
    {
        ParentContext = parentContext;
        ChangeEventCallback = changeEventCallback;
    }

    /// <summary>
    /// Finds an <see cref="HtmlInputRadioContext"/> in the context's ancestors with the matching <paramref name="groupName"/>.
    /// </summary>
    /// <param name="groupName">The group name of the ancestor <see cref="HtmlInputRadioContext"/>.</param>
    /// <returns>The <see cref="HtmlInputRadioContext"/>, or <c>null</c> if none was found.</returns>
    public HtmlInputRadioContext? FindContextInAncestors(string groupName)
    {
        return string.Equals(GroupName, groupName, StringComparison.Ordinal) ? this : ParentContext?.FindContextInAncestors(groupName);
    }
}
