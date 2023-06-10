// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Abstractions;

public class StyleBuilder
{
    private readonly List<string> _styles;

    public StyleBuilder() : this(null)
    {
    }

    public StyleBuilder(string? style)
    {
        _styles = new List<string>();

        if (style is null)
        {
            return;
        }

        var styles = style.Split(';', StringSplitOptions.RemoveEmptyEntries);
        _styles.AddRange(styles);
    }

    public void AddIfValueTrue(bool value, string style)
    {
        if (value)
        {
            _styles.Add(style);
        }
    }

    public void AddIfValueNotNull<T>(T? value, string style)
    {
        if (value is not null)
        {
            _styles.Add(style);
        }
    }

    public void Add(string? style)
    {
        if (!string.IsNullOrEmpty(style))
        {
            _styles.Add(style);
        }
    }

    public string? Build()
    {
        if (_styles.Count == 0)
        {
            return null;
        }

        var built = string.Join(';', _styles);

        if (string.IsNullOrWhiteSpace(built))
        {
            return null;
        }

        return built;
    }
}
