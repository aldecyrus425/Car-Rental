using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Vehicle.Create
{
    public class CreateVehicleValidation : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleValidation()
        {
            RuleFor(x => x.VehicleTypeId)
                .NotEmpty()
                .WithMessage("Vehicle Type ID is required.");

            RuleFor(x => x.PlateNumber)
                .NotEmpty()
                .WithMessage("Plate Number is required.")
                .Length(1, 20)
                .WithMessage("Plate Number must be between 1 and 20 characters.")
                .Matches(@"^[A-Z0-9\-]+$")
                .WithMessage("Plate Number must contain only uppercase letters, digits, and hyphens.");

            RuleFor(x => x.VehicleCode)
                .NotEmpty()
                .WithMessage("Vehicle Code is required.")
                .Length(1, 50)
                .WithMessage("Vehicle Code must be between 1 and 50 characters.");

            RuleFor(x => x.Make)
                .NotEmpty()
                .WithMessage("Make is required.")
                .Length(1, 50)
                .WithMessage("Make must be between 1 and 50 characters.");

            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Model is required.")
                .Length(1, 50)
                .WithMessage("Model must be between 1 and 50 characters.");

            RuleFor(x => x.Year)
                .NotEmpty()
                .WithMessage("Year is required.")
                .GreaterThanOrEqualTo(1900)
                .WithMessage("Year must be 1900 or later.")
                .LessThanOrEqualTo(DateTime.Now.Year + 1)
                .WithMessage("Year cannot be more than one year in the future.");

            RuleFor(x => x.Color)
                .NotEmpty()
                .WithMessage("Color is required.")
                .Length(1, 50)
                .WithMessage("Color must be between 1 and 50 characters.");

            RuleFor(x => x.CurrentMileage)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Current Mileage must be greater than or equal to 0.");

            RuleFor(x => x.FuelLevel)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Fuel Level must be greater than or equal to 0.")
                .LessThanOrEqualTo(1)
                .WithMessage("Fuel Level must be between 0 and 1.");

            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("Status is required.")
                .Must(status => new[] { "Available", "In Use", "Maintenance" }.Contains(status))
                .WithMessage("Status must be one of: Available, In Use, Maintenance.");

            RuleFor(x => x.RegistrationExpiryDate)
                .Must(date => date == null || date.Value >= DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Registration Expiry Date must be in the future.");

            RuleFor(x => x.InsuranceExpiryDate)
                .Must(date => date == null || date.Value >= DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Insurance Expiry Date must be in the future.");

            RuleFor(x => x.BranchId)
                .NotEmpty()
                .WithMessage("Branch ID is required.");
        }
    }
}
