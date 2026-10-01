using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.PricingArea.Create
{
    public class CreatePricingAreaValidation : AbstractValidator<CreatePricingAreaCommand>
    {
        public CreatePricingAreaValidation()
        {
            RuleFor(x => x.Name)
    .NotEmpty().WithMessage("Name is required.")
    .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(50).WithMessage("City cannot exceed 50 characters.");
            RuleFor(x => x.Province)
                .NotEmpty().WithMessage("Province is required.")
                .MaximumLength(50).WithMessage("Province cannot exceed 50 characters.");
            RuleFor(x => x.AreaType)
                .NotEmpty().WithMessage("AreaType is required.")
                .MaximumLength(20).WithMessage("AreaType cannot exceed 20 characters.");
            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive is required.");

        }
    }
}
