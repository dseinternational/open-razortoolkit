// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlForm<TContent> : HtmlContentElement<TContent>
{
    /// <summary>
    /// Space-separated character encodings the server accepts. The browser uses them
    /// in the order in which they are listed. The default value means the same encoding
    /// as the page. 
    /// </summary>
    public string? AcceptCharset { get; set; }

    /// <summary>
    /// The URL that processes the form submission. This value can be overridden by a
    /// formaction attribute on a &lt;button&gt;, &lt;input type="submit"&gt;, or
    /// &lt;input type="image"&gt; element. This attribute is ignored when method="dialog" is set.
    /// </summary>
    public string? Action { get; set; }

    public AutoCapitalize AutoCapitalize { get; set; }

    /// <summary>
    /// Indicates whether input elements can by default have their values automatically completed by the browser.
    /// <c>autocomplete</c> attributes on form elements override it on <c>&lt;form&gt;</c>.
    /// </summary>
    public AutoComplete AutoComplete { get; set; }

    public string? Name { get; set; }

    protected override string OuterElementName => HtmlElements.Form;

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.AcceptCharset, AcceptCharset);
        builder.AddAttribute(++sequence, HtmlAttributes.Name, Name);
        builder.AddAttribute(++sequence, HtmlAttributes.Action, Action);

        switch (AutoCapitalize)
        {
            case AutoCapitalize.None:
                builder.AddAttribute(++sequence, "autocapitalize", "none");
                break;
            case AutoCapitalize.Words:
                builder.AddAttribute(++sequence, "autocapitalize", "words");
                break;
            case AutoCapitalize.Characters:
                builder.AddAttribute(++sequence, "autocapitalize", "characters");
                break;
            case AutoCapitalize.Sentences:
            default:
                break;
        }
        
        switch (AutoComplete)
        {
            case AutoComplete.On:
                builder.AddAttribute(++sequence, HtmlAttributes.Autocomplete, "on");
                break;
            case AutoComplete.Off:
                builder.AddAttribute(++sequence, HtmlAttributes.Autocomplete, "off");
                break;
            case AutoComplete.Default:
            default:
                break;
        }

        return base.AddAttributes(sequence, builder);
    }

}
