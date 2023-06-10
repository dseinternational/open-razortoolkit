// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Globalization;

namespace DSE.Open.RazorToolkit.Core;

/// <summary>
/// Extension methods for working with <see cref="IFormattable"/> objects.
/// </summary>
public static class FormattableExtensions
{
    /// <summary>
    /// Formats the value of the current instance using the default format and the 
    /// <see cref="CultureInfo.InvariantCulture"/> format provider.
    /// </summary>
    /// <param name="formattable">The object to output to a formatted string.</param>
    /// <returns>The value of the current instance in the default format.</returns>
    public static string ToStringInvariant(this IFormattable formattable)
    {
        return formattable.ToString(null, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Formats the value of the current instance using the specified format and the 
    /// <see cref="CultureInfo.InvariantCulture"/> format provider.
    /// </summary>
    /// <param name="formattable">The object to output to a formatted string.</param>
    /// <param name="format"></param>
    /// <returns>The value of the current instance in the specified format.</returns>
    public static string ToStringInvariant(this IFormattable formattable, string? format)
    {
        return formattable.ToString(format, CultureInfo.InvariantCulture);
    }
}
