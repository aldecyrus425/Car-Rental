using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.PricingAreaRule.Create
{
    public class CreatePricingAreaRuleVaidation : AbstractValidator<CreatePricingAreaRuleCommand>
    {
        public CreatePricingAreaRuleVaidation()
        {
            RuleFor(x => x.PricingAreaId)
                .NotEmpty().WithMessage("PricingAreaId is required.");

            RuleFor(x => x.PricingType)
                .NotEmpty().WithMessage("Pricing type is required.")
                .MaximumLength(50).WithMessage("Pricing type must not exceed 50 characters.");

            RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(0).WithMessage("Amount must be zero or a positive value.");

            RuleFor(x => x.MinimumDays)
                .GreaterThanOrEqualTo(0).WithMessage("Minimum days must be zero or a positive value.")
                .When(x => x.MinimumDays.HasValue);

            RuleFor(x => x.MaximumDays)
                .GreaterThanOrEqualTo(0).WithMessage("Maximum days must be zero or a positive value.")
                .When(x => x.MaximumDays.HasValue);

            When(x => x.MinimumDays.HasValue && x.MaximumDays.HasValue, () =>
            {
                RuleFor(x => x.MaximumDays.Value)
                    .GreaterThanOrEqualTo(x => x.MinimumDays.Value)
                    .WithMessage("MaximumDays must be greater than or equal to MinimumDays.");
            });

            RuleFor(x => x.EffectiveFrom)
                .NotEmpty().WithMessage("EffectiveFrom is required.");

            When(x => x.EffectiveTo.HasValue, () =>
            {
                RuleFor(x => x.EffectiveTo.Value)
                    .GreaterThanOrEqualTo(x => x.EffectiveFrom)
                    .WithMessage("EffectiveTo must be the same as or after EffectiveFrom.");
            });
        }
    }
}
