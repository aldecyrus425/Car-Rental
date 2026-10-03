using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.RentalDestination.Create
{
    public class CreateRentalDistinationValidation : AbstractValidator<CreateRentalDistinationCommand>
    {
        private static readonly string[] AllowedDestinationTypes = { "Airport", "Hotel", "Resort", "City", "Port", "Other" };

        public CreateRentalDistinationValidation()
        {
            RuleFor(x => x.AreaId)
                .NotEmpty()
                .WithMessage("Area ID is required.");

            RuleFor(x => x.DestinationName)
                .NotEmpty()
                .WithMessage("Destination Name is required.")
                .MaximumLength(100)
                .WithMessage("Destination Name cannot exceed 100 characters.");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City is required.")
                .MaximumLength(50)
                .WithMessage("City cannot exceed 50 characters.");

            RuleFor(x => x.Province)
                .NotEmpty()
                .WithMessage("Province is required.")
                .MaximumLength(50)
                .WithMessage("Province cannot exceed 50 characters.");

            RuleFor(x => x.DistanceKm)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Distance must be greater than or equal to 0.")
                .When(x => x.DistanceKm.HasValue);

            RuleFor(x => x.DestinationType)
                .NotEmpty()
                .WithMessage("Destination Type is required.")
                .Must(type => AllowedDestinationTypes.Contains(type))
                .WithMessage($"Destination Type must be one of: {string.Join(", ", AllowedDestinationTypes)}");

            RuleFor(x => x.Remarks)
                .MaximumLength(500)
                .WithMessage("Remarks cannot exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Remarks));
        }
    }
}
