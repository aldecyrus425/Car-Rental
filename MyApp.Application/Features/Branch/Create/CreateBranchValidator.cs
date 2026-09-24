using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Branch.Create
{
    public class CreateBranchValidator : AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Branch name is required.").MaximumLength(100).WithMessage("Branch name cannot exceed 100 characters.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.Province).NotEmpty().WithMessage("Province is required.");
            RuleFor(x => x.ContactNumber).NotEmpty().WithMessage("Contact number is required.").Matches(@"^\+?\d{10,15}$").WithMessage("Contact number must be a valid phone number.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive status is required.");
        }
    }
}
