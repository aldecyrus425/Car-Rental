using MediatR;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Users.Reactivate
{
    public class ReactivateUserCommand : IRequest<GenericResponse<string>>
    {
        public Guid UserId { get; set; }
    }
}
