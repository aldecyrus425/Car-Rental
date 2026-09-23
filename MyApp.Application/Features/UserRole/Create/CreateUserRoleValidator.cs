using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.UserRole.Create
{
    public class CreateUserRoleValidator : AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();
        }
    }
}
