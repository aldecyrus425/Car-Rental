using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.RentalAgreement.Create
{
    public class CreateRentalAgreementValidation : AbstractValidator<CreateRentalAgreementCommand>
    {
        private static readonly string[] AllowedStatuses = { "Active", "Completed", "Cancelled", "Pending" };
        private static readonly string[] AllowedRentalTypes = { "Daily", "Weekly", "Monthly", "Hourly" };

        public CreateRentalAgreementValidation()
        {
            // RentalNumber Validation
            RuleFor(x => x.RentalNumber)
                .NotEmpty()
                .WithMessage("Rental Number is required.")
                .MaximumLength(50)
                .WithMessage("Rental Number cannot exceed 50 characters.");

            // CustomerId Validation
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Customer ID is required.");

            // BranchId Validation
            RuleFor(x => x.BranchId)
                .NotEmpty()
                .WithMessage("Branch ID is required.");

            // StartDateTime Validation
            RuleFor(x => x.StartDateTime)
                .NotEmpty()
                .WithMessage("Start Date Time is required.")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Start Date Time must be in the future or today.");

            // ExpectedReturnDateTime Validation
            RuleFor(x => x.ExpectedReturnDateTime)
                .NotEmpty()
                .WithMessage("Expected Return Date Time is required.")
                .GreaterThan(x => x.StartDateTime)
                .WithMessage("Expected Return Date Time must be after Start Date Time.");

            // Status Validation
            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("Status is required.")
                .Must(status => AllowedStatuses.Contains(status))
                .WithMessage($"Status must be one of: {string.Join(", ", AllowedStatuses)}");

            // RentalType Validation
            RuleFor(x => x.RentalType)
                .NotEmpty()
                .WithMessage("Rental Type is required.")
                .Must(type => AllowedRentalTypes.Contains(type))
                .WithMessage($"Rental Type must be one of: {string.Join(", ", AllowedRentalTypes)}");

            // PickupLocation Validation
            RuleFor(x => x.PickupLocation)
                .NotEmpty()
                .WithMessage("Pickup Location is required.")
                .MaximumLength(200)
                .WithMessage("Pickup Location cannot exceed 200 characters.");

            // ReturnLocation Validation
            RuleFor(x => x.ReturnLocation)
                .NotEmpty()
                .WithMessage("Return Location is required.")
                .MaximumLength(200)
                .WithMessage("Return Location cannot exceed 200 characters.");

            // StartingMileage Validation
            RuleFor(x => x.StartingMileage)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Starting Mileage must be greater than or equal to 0.");

            // StartingFuelLevel Validation
            RuleFor(x => x.StartingFuelLevel)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Starting Fuel Level must be greater than or equal to 0.")
                .LessThanOrEqualTo(1)
                .WithMessage("Starting Fuel Level must be between 0 and 1 (0% to 100%).");

            // SubTotal Validation
            RuleFor(x => x.SubTotal)
                .GreaterThanOrEqualTo(0)
                .WithMessage("SubTotal must be greater than or equal to 0.");

            // DiscountAmount Validation
            RuleFor(x => x.DiscountAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Discount Amount must be greater than or equal to 0.")
                .LessThanOrEqualTo(x => x.SubTotal)
                .WithMessage("Discount Amount cannot be greater than SubTotal.");

            // PenaltyAmount Validation
            RuleFor(x => x.PenaltyAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Penalty Amount must be greater than or equal to 0.");

            // AdditionalCharges Validation
            RuleFor(x => x.AdditionalCharges)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Additional Charges must be greater than or equal to 0.");

            // TotalAmount Validation
            RuleFor(x => x.TotalAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Total Amount must be greater than or equal to 0.")
                .Must((cmd, totalAmount) => CalculateTotalAmount(cmd) == totalAmount)
                .WithMessage("Total Amount calculation is incorrect. It should be: SubTotal - DiscountAmount + PenaltyAmount + AdditionalCharges");

            // DepositAmount Validation
            RuleFor(x => x.DepositAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Deposit Amount must be greater than or equal to 0.")
                .LessThanOrEqualTo(x => x.TotalAmount)
                .WithMessage("Deposit Amount cannot be greater than Total Amount.");

            // CreatedBy Validation
            RuleFor(x => x.CreatedBy)
                .NotEmpty()
                .WithMessage("CreatedBy User ID is required.");
        }

        private static decimal CalculateTotalAmount(CreateRentalAgreementCommand cmd)
        {
            return cmd.SubTotal - cmd.DiscountAmount + cmd.PenaltyAmount + cmd.AdditionalCharges;
        }
    }
}
