// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Abstractions.Html;

public static class HtmlInputTypeHelper
{
    public static string GetInputTypeString(HtmlInputType inputType)
    {
        return inputType switch
        {
            HtmlInputType.Text => "text",
            HtmlInputType.Button => "button",
            HtmlInputType.Checkbox => "checkbox",
            HtmlInputType.Color => "color",
            HtmlInputType.Date => "date",
            HtmlInputType.DateTimeLocal => "datetime-local",
            HtmlInputType.Email => "email",
            HtmlInputType.File => "file",
            HtmlInputType.Hidden => "hidden",
            HtmlInputType.Image => "image",
            HtmlInputType.Month => "month",
            HtmlInputType.Number => "number",
            HtmlInputType.Password => "password",
            HtmlInputType.Radio => "radio",
            HtmlInputType.Range => "range",
            HtmlInputType.Reset => "reset",
            HtmlInputType.Search => "search",
            HtmlInputType.Submit => "submit",
            HtmlInputType.Telephone => "tel",
            HtmlInputType.Time => "time",
            HtmlInputType.Url => "url",
            HtmlInputType.Week => "week",
            _ => throw new NotImplementedException()
        };
    }
}
