// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

public abstract class HtmlInputElement<TValue> : HtmlInputBase<TValue>
{
    /// <summary>
    /// If <see langword="true"/>, then the value is updated on the <c>input</c>
    /// event, otherwise the value is updated on the <c>change</c>. Use of the
    /// <c>input</c> event triggers field validation on each keystroke.
    /// </summary>
    [Parameter]
    public bool BindOnInput { get; set; }

    [Parameter]
    public string? FormId { get; set; }

    public abstract HtmlInputType? InputType { get; }

    protected string? InputTypeString => InputType is not null ? HtmlInputTypeHelper.GetInputTypeString(InputType.Value) : null;

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool ReadOnly { get; set; }

    [Parameter]
    public bool Required { get; set; }

    /// <summary>
    /// The value given to the list attribute should be the id of a <c>&lt;datalist&gt;</c> element
    /// located in the same document. The <c>&lt;datalist&gt;</c> provides a list of predefined
    /// values to suggest to the user for this input. Any values in the list that are not compatible
    /// with the type are not included in the suggested options. The values provided are suggestions,
    /// not requirements: users can select from this predefined list or provide a different value.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><see href="https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#list"/></item>
    /// </list>
    /// </remarks>
    [Parameter]
    public string? DataListId { get; set; }

    [Parameter]
    public HtmlInputMode InputMode { get; set; }

    [Parameter]
    public string? Name { get; set; }

    protected override string OuterElementName => HtmlElements.Input;

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.ReadOnly, BindConverter.FormatValue(ReadOnly, CultureInfo.InvariantCulture));
        builder.AddAttribute(++sequence, HtmlAttributes.Required, BindConverter.FormatValue(Required, CultureInfo.InvariantCulture));
        builder.AddAttribute(++sequence, HtmlAttributes.Type, InputTypeString);
        builder.AddAttribute(++sequence, HtmlAttributes.Name, Name);
        builder.AddAttribute(++sequence, HtmlAttributes.InputMode, InputMode.ToAttributeValue(true));
        builder.AddAttribute(++sequence, HtmlAttributes.Form, FormId);
        builder.AddAttribute(++sequence, HtmlAttributes.Disabled, BindConverter.FormatValue(Disabled, CultureInfo.InvariantCulture));
        builder.AddAttribute(++sequence, HtmlAttributes.List, DataListId);

        return base.AddAttributes(++sequence, builder);
    }

    protected override int AddBindings(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.Value, CurrentValueAsString);

        if (BindOnInput)
        {
            builder.AddAttribute(++sequence, "oninput", EventCallback.Factory.CreateBinder(
                this, value => CurrentValue = value, CurrentValue));
        }
        else
        {
            builder.AddAttribute(++sequence, "onchange", EventCallback.Factory.CreateBinder(
                this, value => CurrentValue = value, CurrentValue));
        }

        return ++sequence;
    }
}
