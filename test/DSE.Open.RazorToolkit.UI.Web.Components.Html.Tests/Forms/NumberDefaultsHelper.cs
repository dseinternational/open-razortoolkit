// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.Numerics;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Forms;

internal static class NumberDefaultsHelper
{
    internal static (T min, T max, T value) GetDefaultValues<T>() where T : IMinMaxValue<T>
    {
        return (T.MinValue, T.MaxValue, default!);
    }
}
