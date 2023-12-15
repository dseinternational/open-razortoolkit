// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public class HtmlButton : HtmlContentElement
{
    [Parameter]
    public string? FormId { get; set; }

    [Parameter]
    public string? FormAction { get; set; }

    [Parameter]
    public HtmlFormMethod? FormMethod { get; set; }

    [Parameter]
    public bool IsDisabled { get; set; }

    protected override string OuterElementName => HtmlElements.Button;

    [Parameter]
    public ButtonType ButtonType { get; set; } = ButtonType.Button;

    protected string ButtonTypeString => ButtonType switch
    {
        ButtonType.Button => "button",
        ButtonType.Submit => "submit",
        ButtonType.Reset => "reset",
        _ => throw new InvalidOperationException($"Unsupported {nameof(Abstractions.Html.ButtonType)}")
    };

    [Parameter]
    public EventCallback<MouseEventArgs> Click { get; set; }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.AddAttribute(++sequence, "type", ButtonTypeString);
        builder.AddAttribute(++sequence, "form", FormId);
        builder.AddAttribute(++sequence, "formaction", FormAction);
        builder.AddAttribute(++sequence, "formmethod", FormMethod);
        builder.AddAttribute(++sequence, "disabled", IsDisabled);

        return base.AddAttributes(++sequence, builder);
    }

    protected override int AddBindings(int sequence, RenderTreeBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        if (Click.HasDelegate)
        {
            builder.AddAttribute(++sequence, "onclick", EventCallback.Factory.Create(this, Click));
        }

        return base.AddBindings(++sequence, builder);
    }
}
