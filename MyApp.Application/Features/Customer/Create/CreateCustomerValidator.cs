using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Customer.Create
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator() 
        {
            RuleFor(x => x.CustomersNumber)
            .NotEmpty().WithMessage("Customer number is required.")
            .MaximumLength(20).WithMessage("Customer number must not exceed 20 characters.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("First name must not exceed 100 characters.");

            RuleFor(x => x.MiddleName)
                .MaximumLength(100).WithMessage("Middle name must not exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.MiddleName));

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Last name must not exceed 100 characters.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date of birth must be in the past.")
                .GreaterThan(DateOnly.FromDateTime(DateTime.Now.AddYears(-120))).WithMessage("Date of birth is not valid.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .MaximumLength(20).WithMessage("Gender must not exceed 20 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email address is required.")
                .MaximumLength(255).WithMessage("Email must not exceed 255 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[0-9\s\-()]{7,15}$").WithMessage("Phone number is not valid.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(255).WithMessage("Address must not exceed 255 characters.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(100).WithMessage("City must not exceed 100 characters.");

            RuleFor(x => x.Province)
                .NotEmpty().WithMessage("Province is required.")
                .MaximumLength(100).WithMessage("Province must not exceed 100 characters.");

            RuleFor(x => x.PostalCode)
                .MaximumLength(20).WithMessage("Postal code must not exceed 20 characters.")
                .When(x => !string.IsNullOrEmpty(x.PostalCode));

            RuleFor(x => x.EmergencyContactName)
                .MaximumLength(100).WithMessage("Emergency contact name must not exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.EmergencyContactName));

            RuleFor(x => x.EmergencyNumber)
                .Matches(@"^\+?[0-9\s\-()]{7,15}$").WithMessage("Emergency number is not valid.")
                .When(x => !string.IsNullOrEmpty(x.EmergencyNumber));

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(20).WithMessage("Status must not exceed 20 characters.");
        }
    }
}
