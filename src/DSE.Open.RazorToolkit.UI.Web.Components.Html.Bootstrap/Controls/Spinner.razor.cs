// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using DSE.Open.RazorToolkit.UI.Abstractions;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap.Controls;

public partial class Spinner
{
    public const string DefaultDescription = "Loading...";

    /// <summary>
    /// The description of the spinner for screen readers.
    /// </summary>
    [Parameter]
    public string Description { get; set; } = DefaultDescription;

    [Parameter]
    public SpinnerType SpinnerType { get; set; }

    [Parameter]
    public BootstrapTheme Theme { get; set; }

    /// <note>
    /// For large sizes, set the width and height with utility classes.
    /// </note>
    [Parameter]
    public bool Small { get; set; }

    private string SpinnerTypeClass => SpinnerType switch
    {
        SpinnerType.Border => BootstrapClasses.SpinnerBorder,
        SpinnerType.Grow => BootstrapClasses.SpinnerGrow,
        _ => throw new ArgumentOutOfRangeException()
    };

    private string SpinnerThemeClass => Theme switch
    {
        BootstrapTheme.Primary => BootstrapClasses.TextPrimary,
        BootstrapTheme.Secondary => BootstrapClasses.TextSecondary,
        BootstrapTheme.Success => BootstrapClasses.TextSuccess,
        BootstrapTheme.Danger => BootstrapClasses.TextDanger,
        BootstrapTheme.Warning => BootstrapClasses.TextWarning,
        BootstrapTheme.Info => BootstrapClasses.TextInfo,
        BootstrapTheme.Light => BootstrapClasses.TextLight,
        BootstrapTheme.Dark => BootstrapClasses.TextDark,
        _ => string.Empty
    };

    private string SpinnerSmallClass => SpinnerType switch
    {
        SpinnerType.Border => BootstrapClasses.SpinnerBorderSm,
        SpinnerType.Grow => BootstrapClasses.SpinnerGrowSm,
        _ => throw new ArgumentOutOfRangeException()
    };

    protected override void BuildClasses(ClassBuilder classBuilder)
    {
        Guard.IsNotNull(classBuilder);
        classBuilder.Add(SpinnerTypeClass);
        classBuilder.Add(SpinnerThemeClass);
        classBuilder.AddIfValueTrue(Small, SpinnerSmallClass);
        base.BuildClasses(classBuilder);
    }
}
