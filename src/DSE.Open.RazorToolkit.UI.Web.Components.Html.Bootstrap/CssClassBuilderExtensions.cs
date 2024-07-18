// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using DSE.Open.RazorToolkit.UI.Abstractions;
using DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Forms;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

public static class ClassBuilderExtensions
{
    public static void ApplyBackgroundColor(this ClassBuilder classBuilder, BackgroundColor backgroundColor)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);

        switch (backgroundColor)
        {
            case BackgroundColor.Primary:
                classBuilder.Add(BootstrapClasses.BackgroundPrimary);
                break;
            case BackgroundColor.Secondary:
                classBuilder.Add(BootstrapClasses.BackgroundSecondary);
                break;
            case BackgroundColor.Success:
                classBuilder.Add(BootstrapClasses.BackgroundSuccess);
                break;
            case BackgroundColor.Danger:
                classBuilder.Add(BootstrapClasses.BackgroundDanger);
                break;
            case BackgroundColor.Warning:
                classBuilder.Add(BootstrapClasses.BackgroundWarning);
                break;
            case BackgroundColor.Info:
                classBuilder.Add(BootstrapClasses.BackgroundInfo);
                break;
            case BackgroundColor.Light:
                classBuilder.Add(BootstrapClasses.BackgroundLight);
                break;
            case BackgroundColor.Dark:
                classBuilder.Add(BootstrapClasses.BackgroundDark);
                break;
            case BackgroundColor.Body:
                classBuilder.Add(BootstrapClasses.BackgroundBody);
                break;
            case BackgroundColor.White:
                classBuilder.Add(BootstrapClasses.BackgroundWhite);
                break;
            case BackgroundColor.Transparent:
                classBuilder.Add(BootstrapClasses.BackgroundTransparent);
                break;
        }
    }

    public static void ApplyContainerStyle(this ClassBuilder classBuilder, ContainerType container)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);

        switch (container)
        {
            case ContainerType.Default:
                classBuilder.Add(BootstrapClasses.Container);
                break;
            case ContainerType.Fluid:
                classBuilder.Add(BootstrapClasses.ContainerFluid);
                break;
            case ContainerType.Small:
                classBuilder.Add(BootstrapClasses.ContainerSm);
                break;
            case ContainerType.Medium:
                classBuilder.Add(BootstrapClasses.ContainerMd);
                break;
            case ContainerType.Large:
                classBuilder.Add(BootstrapClasses.ContainerLg);
                break;
            case ContainerType.Xl:
                classBuilder.Add(BootstrapClasses.ContainerXl);
                break;
            case ContainerType.Xxl:
                classBuilder.Add(BootstrapClasses.ContainerXxl);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(container), container, null);
        }
    }

    public static void ApplyTextColor(this ClassBuilder classBuilder, TextColor textColor)
    {
        ArgumentNullException.ThrowIfNull(classBuilder);

        switch (textColor)
        {
            case TextColor.Primary:
                classBuilder.Add(BootstrapClasses.TextPrimary);
                break;
            case TextColor.Secondary:
                classBuilder.Add(BootstrapClasses.TextSecondary);
                break;
            case TextColor.Success:
                classBuilder.Add(BootstrapClasses.TextSuccess);
                break;
            case TextColor.Danger:
                classBuilder.Add(BootstrapClasses.TextDanger);
                break;
            case TextColor.Warning:
                classBuilder.Add(BootstrapClasses.TextWarning);
                break;
            case TextColor.Info:
                classBuilder.Add(BootstrapClasses.TextInfo);
                break;
            case TextColor.Light:
                classBuilder.Add(BootstrapClasses.TextLight);
                break;
            case TextColor.Dark:
                classBuilder.Add(BootstrapClasses.TextDark);
                break;
            case TextColor.Body:
                classBuilder.Add(BootstrapClasses.TextBody);
                break;
            case TextColor.White:
                classBuilder.Add(BootstrapClasses.TextWhite);
                break;
        }
    }

    public static void AddFormControlClasses(this ClassBuilder builder, IFormControl formControl)
    {
        builder.Add(formControl.PlainText ? BootstrapClasses.FormControlPlaintext : BootstrapClasses.FormControl);

        switch (formControl.ControlSize)
        {
            case BootstrapSize.Small:
                builder.Add(BootstrapClasses.FormControlSm);
                break;
            case BootstrapSize.Large:
                builder.Add(BootstrapClasses.FormControlLg);
                break;
        }
    }
}
