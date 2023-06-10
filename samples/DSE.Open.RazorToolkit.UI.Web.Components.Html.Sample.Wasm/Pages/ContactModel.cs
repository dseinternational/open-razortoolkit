// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using System.ComponentModel.DataAnnotations;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Sample.Wasm.Pages;

public class ContactModel
{
    [Required]
    [StringLength(10, ErrorMessage = "FirstName is too long.")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(10, ErrorMessage = "LastName is too long.")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required]
    public bool HasAgreed { get; set; }

}
