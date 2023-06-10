// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.RazorToolkit.UI.Core;

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

public abstract class SvgComponent : ViewComponent
{
    [Parameter(CaptureUnmatchedValues = true)]
    public virtual IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// Assigns a class name or set of class names to an element. You may assign the same class
    /// name or names to any number of elements, however, multiple class names must be separated
    /// by whitespace characters.
    /// </summary>
    /// <remarks>
    /// Reference <see href="https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/class"/>
    /// </remarks>
    [Parameter]
    public virtual string? CssClass { get; set; }

    /// <summary>
    /// The style attribute allows to style an element using CSS declarations. It functions
    /// identically to the style attribute in HTML.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/style"/>
    /// </remarks>
    [Parameter]
    public virtual string? CssStyle { get; set; }

    /// <summary>
    /// Gets the combined component-defined and user-defined CSS classes. Derived implementations
    /// will typically use/bind to this value for outputting the value of the <b>class</b> attribute
    /// and override <see cref="BuildClasses(ClassBuilder)"/> to participate in CSS customization.
    /// </summary>
    public string? ComponentClass
    {
        get
        {
            var cssBuilder = new ClassBuilder(CssClass);

            if (AdditionalAttributes is not null
                && AdditionalAttributes.TryGetValue("class", out var customClass)
                && customClass is not null)
            {
                var customClassesStr = customClass.ToString();
                if (customClassesStr is not null)
                {
                    var classes = customClassesStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var c in classes)
                    {
                        cssBuilder.Add(c);
                    }
                }
            }

            BuildClasses(cssBuilder);

            return cssBuilder.Build();
        }
    }

    /// <summary>
    /// Gets the combined component-defined and user-defined CSS styles. Derived implementations
    /// will typically use/bind to this value for outputting the value of the <b>style</b> attribute
    /// and override <see cref="BuildStyles(StyleBuilder)"/> to participate in CSS styles customization.
    /// </summary>
    public string? ComponentStyle
    {
        get
        {
            var styleBuilder = new StyleBuilder(CssStyle);

            if (AdditionalAttributes is not null
                && AdditionalAttributes.TryGetValue("style", out var customStyle)
                && customStyle is not null)
            {
                var customStylesStr = customStyle.ToString();
                if (customStylesStr is not null)
                {
                    var styles = customStylesStr.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var s in styles)
                    {
                        styleBuilder.Add(s);
                    }
                }
            }

            BuildStyles(styleBuilder);

            return styleBuilder.Build();
        }
    }

    /// <summary>
    /// The id attribute assigns a unique name to an element. You can use this attribute with any SVG element.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/id"/>
    /// </remarks>
    [Parameter]
    public string? Id { get; set; }

    /// <summary>
    /// The tabindex attribute allows you to control whether an element is focusable
    /// and to define the relative order of the element for the purposes of sequential
    /// focus navigation. You can use this attribute with any SVG element.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/tabindex"/>
    /// </remarks>
    [Parameter]
    public int? TabIndex { get; set; }

    /// <summary>
    /// The lang attribute specifies the primary language used in contents and attributes containing
    /// text content of particular elements.
    /// </summary>
    /// <remarks>
    /// Reference: <see href="https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/lang"/>
    /// </remarks>
    public string? Language { get; set; }

    protected virtual void BuildClasses(ClassBuilder classBuilder)
    {
    }

    protected virtual void BuildStyles(StyleBuilder styleBuilder)
    {
    }
}
