using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Customer.UpdateStatus
{
    public class UpdateStatusCustomerValidator : AbstractValidator<UpdateStatusCustomerCommand>
    {
        public UpdateStatusCustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId is required.").NotEqual(Guid.Empty).WithMessage("CustomerId cannot be an empty GUID.");

            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is required.");

        }
    }
}
