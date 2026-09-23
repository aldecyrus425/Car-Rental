using MediatR;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Customer.Create
{
    public class CreateCustomerCommand : IRequest<GenericResponse<string>>
    {
        public string CustomersNumber { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string? PostalCode { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyNumber { get; set; }
        public string Status { get; set; }
    }
}
