using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Users.Reactivate
{
    public class ReactivateUserValidator : AbstractValidator<ReactivateUserCommand>
    {
        public ReactivateUserValidator() 
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
