using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CustomerDocument.Create
{
    public class CreateCustomerDocumentValidator : AbstractValidator<CreateCustomerDocumentCommand>
    {
        public CreateCustomerDocumentValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required.");
            RuleFor(x => x.DocumentType)
                .NotEmpty().WithMessage("DocumentType is required.")
                .MaximumLength(100).WithMessage("DocumentType cannot exceed 100 characters.");
            RuleFor(x => x.DocumentNumber)
                .MaximumLength(50).WithMessage("DocumentNumber cannot exceed 50 characters.");
            RuleFor(x => x.ExpirationDate)
                .Must(date => date == null || date > DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("ExpirationDate must be a future date if provided.");
            RuleFor(x => x.VerifiedByUserId)
                .Must((command, verifiedByUserId) => !command.IsVerified || (verifiedByUserId != null && verifiedByUserId != Guid.Empty))
                .WithMessage("VerifiedByUserId must be provided when IsVerified is true.");
            RuleFor(x => x.Remarks)
                .MaximumLength(500).WithMessage("Remarks cannot exceed 500 characters.");
        }
    }
}
