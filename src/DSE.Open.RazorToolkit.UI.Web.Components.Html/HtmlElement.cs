// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

/// <summary>
/// A <see cref="HtmlComponent"/> that renders a <i>single</i> standard HTML element
/// without child content.
/// </summary>
public abstract class HtmlElement : HtmlComponent
{
    /// <summary>
    /// Gets a reference to the rendered HTML element.
    /// </summary>
    [DisallowNull] public ElementReference? Element { get; protected set; }

    protected abstract string OuterElementName { get; }


    [Parameter]
    public virtual char? AccessKey { get; set; }

    /// <summary>
    /// Gets or sets a value indicating that an element should be focused on page load,
    /// or when the <c>&lt;dialog&gt;</c> that it is part of is displayed. Rendered to the <b>autofocus</b>
    /// global attribute.
    /// </summary>
    [Parameter]
    public bool AutoFocus { get; set; }

    [Parameter]
    public bool Hidden { get; set; }

    [Parameter]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the item id of the element. Rendered to the <b>itemid</b> global attribute.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><see href="https://developer.mozilla.org/docs/Web/HTML/Global_attributes/itemid"/></item>
    /// </list>
    /// </remarks>
    [Parameter]
    public string? ItemId { get; set; }

    [Parameter]
    public string? ItemPropertyName { get; set; }

    [Parameter]
    public int? TabIndex{ get; set; }

    /// <summary>
    /// Gets or sets the tooltip. Rendered to the <b>title</b> global attribute.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><see href="https://developer.mozilla.org/docs/Web/HTML/Global_attributes/title"/></item>
    /// </list>
    /// </remarks>
    [Parameter]
    public string? Title { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, OuterElementName);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        var sequence = AddAttributes(2, builder);
        sequence = AddBindings(++sequence, builder);
        sequence = AddContent(++sequence, builder);
        builder.AddElementReferenceCapture(++sequence, inputReference => Element = inputReference);
        builder.CloseElement();
    }

    /// <summary>
    /// Called to write simple (non-event) attributes to the <see cref="RenderTreeBuilder"/>.
    /// </summary>
    /// <param name="sequence">The next sequence value to use.</param>
    /// <param name="builder"></param>
    protected virtual int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.Id, Id);
        builder.AddAttribute(++sequence, HtmlAttributes.Lang, Language);
        builder.AddAttribute(++sequence, HtmlAttributes.Title, Title);

        builder.AddAttribute(++sequence, HtmlAttributes.Class, ComponentClass);

        builder.AddAttribute(++sequence, HtmlAttributes.Style, ComponentStyle);

        builder.AddAttribute(++sequence, HtmlAttributes.AccessKey, AccessKey);
        builder.AddAttribute(++sequence, HtmlAttributes.TabIndex, BindConverter.FormatValue(TabIndex, CultureInfo.InvariantCulture));

        builder.AddAttribute(++sequence, HtmlAttributes.ItemProperty, ItemPropertyName);
        builder.AddAttribute(++sequence, HtmlAttributes.ItemId, ItemId);

        builder.AddAttribute(++sequence, HtmlAttributes.AutoFocus, BindConverter.FormatValue(AutoFocus, CultureInfo.InvariantCulture));
        builder.AddAttribute(++sequence, HtmlAttributes.Hidden, BindConverter.FormatValue(Hidden, CultureInfo.InvariantCulture));

        return ++sequence;
    }

    protected virtual int AddBindings(int sequence, RenderTreeBuilder builder)
    {
        return sequence;
    }

    protected virtual int AddContent(int sequence, RenderTreeBuilder builder)
    {
        return sequence;
    }
}
