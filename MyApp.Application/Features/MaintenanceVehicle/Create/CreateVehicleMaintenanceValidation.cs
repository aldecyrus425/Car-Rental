using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.MaintenanceVehicle.Create
{
    public class CreateVehicleMaintenanceValidation : AbstractValidator<CreateMaintenanceVehicleCommand>
    {
        public CreateVehicleMaintenanceValidation()
        {
            RuleFor(x => x.VehicleId)
                .NotEmpty().WithMessage("VehicleId is required.");

            RuleFor(x => x.MaintenanceType)
                .NotEmpty().WithMessage("Maintenance type is required.")
                .MaximumLength(100).WithMessage("Maintenance type must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.")
                .Must(d => d <= DateTime.UtcNow).WithMessage("Start date cannot be in the future.");

            When(x => x.CompletionDate.HasValue, () =>
            {
                RuleFor(x => x.CompletionDate.Value)
                    .Must((cmd, comp) => comp >= cmd.StartDate).WithMessage("Completion date cannot be before start date.")
                    .Must(comp => comp <= DateTime.UtcNow).WithMessage("Completion date cannot be in the future.");
            });

            RuleFor(x => x.Mileage)
                .GreaterThanOrEqualTo(0).WithMessage("Mileage must be zero or a positive value.");

            RuleFor(x => x.Cost)
                .GreaterThanOrEqualTo(0).WithMessage("Cost must be zero or a positive value.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(50).WithMessage("Status must not exceed 50 characters.");

            RuleFor(x => x.ServiceProvider)
                .MaximumLength(200).WithMessage("Service provider must not exceed 200 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.ServiceProvider));

            RuleFor(x => x.Remarks)
                .MaximumLength(500).WithMessage("Remarks must not exceed 500 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.Remarks));

            RuleFor(x => x.CreateByUserId)
                .NotEmpty().WithMessage("CreateByUserId is required.");
        }
    }
}
