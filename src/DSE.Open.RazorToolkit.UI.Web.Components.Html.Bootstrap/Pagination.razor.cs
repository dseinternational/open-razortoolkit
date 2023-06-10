// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using Microsoft.AspNetCore.Components;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Bootstrap;

/// <summary>
/// A component that indicates a series of related content exists across multiple pages
/// and supports navigation.
/// </summary>
/// <remarks>
/// <see href="https://getbootstrap.com/docs/5.2/components/pagination/" />
/// </remarks>
public partial class Pagination
{
    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public BootstrapSize BootstrapSize { get; set; } = BootstrapSize.Default;

    public string ListClass()
    {
        if (BootstrapSize is BootstrapSize.Default)
        {
            return BootstrapClasses.Pagination;
        }

        var sizeClass = BootstrapSize switch
        {
            BootstrapSize.Small => BootstrapClasses.PaginationSm,
            BootstrapSize.Large => BootstrapClasses.PaginationLg
        };

        return $"{BootstrapClasses.Pagination} {sizeClass}";
    }
}
