using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.RentalVehicle.Create
{
    public class CreateRentalVehicleValidation : AbstractValidator<CreateRentalVehicleCommand>
    {
        public CreateRentalVehicleValidation()
        {
            RuleFor(x => x.VehicleId)
                .NotEmpty()
                .WithMessage("Vehicle ID is required.");

            RuleFor(x => x.DailyRate)
                .GreaterThan(0)
                .WithMessage("Daily Rate must be greater than 0.");

            RuleFor(x => x.NumberOfDays)
                .GreaterThan(0)
                .WithMessage("Number of Days must be greater than 0.");
        }
    }
}
