// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Abstractions;

/// <summary>
/// Helper for building CSS <c>class</c> attribute values.
/// </summary>
public class ClassBuilder
{
    private readonly List<string> _classes;

    public ClassBuilder() : this(null)
    {
    }

    public ClassBuilder(string? cssClass)
    {
        _classes = new List<string>();

        if (cssClass is null)
        {
            return;
        }

        var classes = cssClass.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        _classes.AddRange(classes);
    }

    public void AddIfValueTrue(bool value, string cssClass)
    {
        if (value)
        {
            _classes.Add(cssClass);
        }
    }

    public void AddIfValueNotNull<T>(T? value, string cssClass)
    {
        if (value is not null)
        {
            _classes.Add(cssClass);
        }
    }

    public void Add(string? cssClass)
    {
        if (!string.IsNullOrEmpty(cssClass))
        {
            _classes.Add(cssClass);
        }
    }

    public string? Build()
    {
        if (_classes.Count == 0)
        {
            return null;
        }

        var built = string.Join(' ', _classes);

        if (string.IsNullOrWhiteSpace(built))
        {
            return null;
        }

        return built;
    }
}
