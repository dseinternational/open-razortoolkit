// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using DSE.Open.RazorToolkit.UI.Abstractions.Html;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

/// <summary>
/// An input component for editing <see cref="string"/> values.
/// </summary>
public class HtmlInputText : HtmlTextInputElement
{
    public override HtmlInputType? InputType => HtmlInputType.Text;

    [Parameter]
    public int? Size { get; set; }

    [Parameter]
    public string? Pattern { get; set; }

    /// <inheritdoc />
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    protected override bool TryParseValueFromString(string? value, out string? result,
        [NotNullWhen(false)] out string? validationErrorMessage)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    {
        result = value;
        validationErrorMessage = null;
        return true;
    }

    protected override int AddAttributes(int sequence, RenderTreeBuilder builder)
    {
        builder.AddAttribute(++sequence, HtmlAttributes.MaxLength, MaxLength?.ToStringInvariant());
        builder.AddAttribute(++sequence, HtmlAttributes.MinLength, MinLength?.ToStringInvariant());
        builder.AddAttribute(++sequence, HtmlAttributes.Size, Size?.ToStringInvariant());
        builder.AddAttribute(++sequence, HtmlAttributes.AutoFocus, AutoFocus);
        builder.AddAttribute(++sequence, HtmlAttributes.Placeholder, Placeholder);
        builder.AddAttribute(++sequence, HtmlAttributes.SpellCheck, SpellCheck);
        builder.AddAttribute(++sequence, HtmlAttributes.Pattern, Pattern);
        builder.AddAttribute(++sequence, HtmlAttributes.AutoCapitalize, AutoCapitalizeToString());

        return base.AddAttributes(++sequence, builder);
    }

    private string? AutoCapitalizeToString()
    {
        switch (AutoCapitalize)
        {
            case AutoCapitalize.Sentences:
                return "sentences";
            case AutoCapitalize.Words:
                return "words";
            case AutoCapitalize.Characters:
                return "characters";
        }

        return null;
    }
}
