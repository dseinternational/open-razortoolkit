// Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
// Down Syndrome Education International and Contributors licence this file to you under the MIT license.

using FluentValidation;

namespace DSE.Open.RazorToolkit.UI.Web.Components.Html.Sample.Wasm.Pages.Bootstrap.Forms;

public class ContactValidator : AbstractValidator<ContactModel>
{
    public ContactValidator()
    {
        RuleFor(contact => contact.FirstName).NotEmpty();
        RuleFor(contact => contact.LastName).NotEmpty();
        RuleFor(contact => contact.DateOfBirth).LessThan(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("Date of birth must be in the past");
    }
}
