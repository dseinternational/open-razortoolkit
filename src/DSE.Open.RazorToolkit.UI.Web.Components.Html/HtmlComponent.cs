// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.Drawing;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

/// <summary>
/// A <see cref="WebComponent"/> that renders a HTML content.
/// </summary>
public abstract class HtmlComponent : WebComponent
{
    [Parameter(CaptureUnmatchedValues = true)]
    public virtual IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// Gets or sets a space-separated list of the classes of the element. Combined with any
    /// component-defined CSS classes and rendered to the <b>class</b> global attribute.
    /// <para>Derived implementations should bind to <see cref="ComponentClass"/> to ensure
    /// that any component-defined CSS classes are added.</para>
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><see href="https://developer.mozilla.org/docs/Web/HTML/Global_attributes/class"/></item>
    /// </list>
    /// </remarks>
    [Parameter]
    public virtual string? CssClass { get; set; }

    /// <summary>
    /// Gets or sets CSS styling declarations to be applied to the element. Rendered to
    /// the <b>style</b> global attribute.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><see href="https://developer.mozilla.org/docs/Web/HTML/Global_attributes/style"/></item>
    /// </list>
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
                && AdditionalAttributes.TryGetValue(HtmlAttributes.Class, out var customClass)
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
                && AdditionalAttributes.TryGetValue(HtmlAttributes.Style, out var customStyle)
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
    /// Gets or sets localization/globalization language information that applies to a component,
    /// and also to all child elements of the current component.
    /// </summary>
    [Parameter]
    public string? Language { get; set; }

    protected virtual void BuildClasses(ClassBuilder classBuilder)
    {
    }

    protected virtual void BuildStyles(StyleBuilder styleBuilder)
    {
    }

}
