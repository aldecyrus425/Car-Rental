using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.VehicleType.Create
{
    public class CreateVehicleTypeValidation : AbstractValidator<CreateVehicleTypeCommand>
    {
        public CreateVehicleTypeValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));

            RuleFor(x => x.SeatingCapacity)
                .GreaterThan(0).WithMessage("Seating capacity must be greater than zero.");

            RuleFor(x => x.TransmissionType)
                .NotEmpty().WithMessage("Transmission type is required.")
                .MaximumLength(50).WithMessage("Transmission type must not exceed 50 characters.");

            RuleFor(x => x.FuelType)
                .NotEmpty().WithMessage("Fuel type is required.")
                .MaximumLength(50).WithMessage("Fuel type must not exceed 50 characters.");

            RuleFor(x => x.DailyBaseRate)
                .GreaterThanOrEqualTo(0).WithMessage("Daily base rate must be zero or a positive value.");
        }
    }
}
