// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Graphics.Components.Svg;

public class LengthTests
{
    [Theory]
    [InlineData("1px", 1, LengthUnits.Pixel)]
    [InlineData("1846972px", 1846972, LengthUnits.Pixel)]
    [InlineData("1000em", 1000, LengthUnits.Em)]
    [InlineData("001%", 1, LengthUnits.Percentage)]
    public void ParseReturnsExpectedValues(string value, int expectedValue, LengthUnits expectedUnits)
    {
        Assert.True(Length.TryParse(value, out var length));
        Assert.Equal(expectedValue, length.Value);
        Assert.Equal(expectedUnits, length.UnitType);
    }
}
