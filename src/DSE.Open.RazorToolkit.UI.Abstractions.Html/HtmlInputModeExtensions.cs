// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Abstractions.Html;

public static class HtmlInputModeExtensions
{
    private static readonly Dictionary<HtmlInputMode, string> s_inputModeValues =
        Enum.GetValues<HtmlInputMode>().ToDictionary(id => id, id => Enum.GetName(id)!.ToLowerInvariant());

    public static string? ToAttributeValue(this HtmlInputMode value, bool returnNoneAsNull = false)
    {
        if (returnNoneAsNull && value == HtmlInputMode.None)
        {
            return null;
        }
        return s_inputModeValues[value];
    }

    public static string? ToAttributeValue(this HtmlInputMode? value, bool returnNoneAsNull = false)
    {
        if (value is null || (returnNoneAsNull && value == HtmlInputMode.None))
        {
            return null;
        }
        return s_inputModeValues[value.Value];
    }
}
