using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

/// <summary>
/// Base for elements typically laid out as block elements.
/// </summary>
public class HtmlSection : HtmlContentElement
{
    protected override string OuterElementName => HtmlElements.Section;
}
