// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

/// <summary>
/// A <see cref="SvgComponent"/> that renders a <i>single</i> standard SVG element
/// without child content.
/// </summary>
public abstract class SvgElement : SvgComponent
{
    /// <summary>
    /// Gets a reference to the rendered HTML element.
    /// </summary>
    [DisallowNull] public ElementReference? Element { get; protected set; }

    protected abstract string OuterElementName { get; }

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
        builder.AddAttribute(++sequence, "id", Id);
        builder.AddAttribute(++sequence, "lang", Language);
        builder.AddAttribute(++sequence, "tabindex", TabIndex);

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
