using MediatR;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Customer.UpdateStatus
{
    public class UpdateStatusCustomerCommand : IRequest<GenericResponse<string>>
    {
        public Guid CustomerId { get; set; }
        public string Status { get; set; }
    }
}
