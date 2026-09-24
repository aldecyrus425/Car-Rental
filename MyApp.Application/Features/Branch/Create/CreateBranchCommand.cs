using MediatR;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Branch.Create
{
    public class CreateBranchCommand : IRequest<GenericResponse<string>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ContactNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
