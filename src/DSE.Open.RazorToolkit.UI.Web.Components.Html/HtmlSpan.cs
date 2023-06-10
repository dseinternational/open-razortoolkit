


using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public abstract class HtmlSpan : HtmlInline
{
    protected override string OuterElementName => HtmlElements.Span;
}
