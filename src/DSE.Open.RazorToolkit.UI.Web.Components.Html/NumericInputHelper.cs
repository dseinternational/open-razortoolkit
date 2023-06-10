// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.Extensions.Logging;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html;

public static class NumericInputHelper
{
    public static object? GetDefaultMin<TValue>()
    {
        var targetType = Nullable.GetUnderlyingType(typeof(TValue));

        if (targetType is not null)
        {
            return null;
        }

        targetType = typeof(TValue);

        if (targetType == typeof(int))
        {
            return int.MinValue;
        }

        if (targetType == typeof(long))
        {
            return long.MinValue;
        }

        if (targetType == typeof(short))
        {
            return short.MinValue;
        }

        if (targetType == typeof(float))
        {
            return float.MinValue;
        }

        if (targetType == typeof(double))
        {
            return double.MinValue;
        }

        if (targetType == typeof(decimal))
        {
            return decimal.MinValue;
        }

        throw new InvalidOperationException($"The type '{targetType}' is not a supported numeric type.");
    }

    public static object? GetDefaultMax<TValue>()
    {
        var targetType = Nullable.GetUnderlyingType(typeof(TValue));

        if (targetType is not null)
        {
            return null;
        }

        targetType = typeof(TValue);

        if (targetType == typeof(int))
        {
            return int.MaxValue;
        }

        if (targetType == typeof(long))
        {
            return long.MaxValue;
        }

        if (targetType == typeof(short))
        {
            return short.MaxValue;
        }

        if (targetType == typeof(float))
        {
            return float.MaxValue;
        }

        if (targetType == typeof(double))
        {
            return double.MaxValue;
        }

        if (targetType == typeof(decimal))
        {
            return decimal.MaxValue;
        }

        throw new InvalidOperationException($"The type '{targetType}' is not a supported numeric type.");
    }

    public static object? GetDefaultStep<TValue>()
    {
        var targetType = Nullable.GetUnderlyingType(typeof(TValue));

        if (targetType is not null)
        {
            return null;
        }

        targetType = typeof(TValue);

        if (targetType == typeof(int))
        {
            return DefaultNumericInputSteps.IntStep;
        }

        if (targetType == typeof(long))
        {
            return DefaultNumericInputSteps.LongStep;
        }

        if (targetType == typeof(short))
        {
            return DefaultNumericInputSteps.ShortStep;
        }

        if (targetType == typeof(float))
        {
            return DefaultNumericInputSteps.FloatStep;
        }

        if (targetType == typeof(double))
        {
            return DefaultNumericInputSteps.DoubleStep;
        }

        if (targetType == typeof(decimal))
        {
            return DefaultNumericInputSteps.DecimalStep;
        }

        throw new InvalidOperationException($"The type '{targetType}' is not a supported numeric type.");
    }

    public static string? GetAttributeMinValue<TValue>(TValue value)
    {
        if (value is null)
        {
            return null;
        }

        var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);

        if (targetType == typeof(int) && Convert.ToInt32(value) == int.MinValue)
        {
            return null;
        }

        if (targetType == typeof(long) && Convert.ToInt64(value) == long.MinValue)
        {
            return null;
        }

        if (targetType == typeof(short) && Convert.ToInt16(value) == short.MinValue)
        {
            return null;
        }

        if (targetType == typeof(float) && Convert.ToSingle(value) == float.MinValue)
        {
            return null;
        }

        if (targetType == typeof(double) && Convert.ToDouble(value) == double.MinValue)
        {
            return null;
        }

        if (targetType == typeof(decimal) && Convert.ToDecimal(value) == decimal.MinValue)
        {
            return null;
        }

        switch (value)
        {
            case int.MinValue:
            case long.MinValue:
            case short.MinValue:
            case float.MinValue:
            case double.MinValue:
            case decimal.MinValue:
                return null;
        }

        return value.ToString();
    }

    public static string? GetAttributeMaxValue<TValue>(TValue value)
    {
        if (value is null)
        {
            return null;
        }

        var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);

        if (targetType == typeof(int) && Convert.ToInt32(value) == int.MaxValue)
        {
            return null;
        }

        if (targetType == typeof(long) && Convert.ToInt64(value) == long.MaxValue)
        {
            return null;
        }

        if (targetType == typeof(short) && Convert.ToInt16(value) == short.MaxValue)
        {
            return null;
        }

        if (targetType == typeof(float) && Convert.ToSingle(value) == float.MaxValue)
        {
            return null;
        }

        if (targetType == typeof(double) && Convert.ToDouble(value) == double.MaxValue)
        {
            return null;
        }

        if (targetType == typeof(decimal) && Convert.ToDecimal(value) == decimal.MaxValue)
        {
            return null;
        }

        switch (value)
        {
            case int.MaxValue:
            case long.MaxValue:
            case short.MaxValue:
            case float.MaxValue:
            case double.MaxValue:
            case decimal.MaxValue:
                return null;
        }

        return value.ToString();
    }
}
