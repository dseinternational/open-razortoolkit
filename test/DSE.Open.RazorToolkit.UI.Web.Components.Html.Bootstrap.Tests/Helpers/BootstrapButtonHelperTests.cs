// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Helpers;

public class BootstrapButtonHelperTests
{
    [Fact]
    public void GetButtonThemeCss_WithPrimaryStyle_ShouldReturnButtonPrimaryClass()
    {
        // Arrange
        const string expected = BootstrapClasses.ButtonPrimary;

        // Act
        var actual = ButtonHelper.GetButtonThemeCss(ButtonStyle.Primary);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetButtonSizeCss_WithLargeSize_ShouldReturnButtonLargeCss()
    {
        // Arrange
        const string expected = BootstrapClasses.ButtonLg;

        // Act
        var actual = ButtonHelper.GetButtonSizeCss(BootstrapSize.Large);

        // Assert
        Assert.Equal(expected, actual);
    }
}
