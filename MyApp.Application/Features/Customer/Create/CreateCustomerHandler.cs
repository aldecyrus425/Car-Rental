using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Customer.Create
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, GenericResponse<string>>
    {
        private readonly ICustomerRepository _customerRepo;

        public CreateCustomerHandler(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<GenericResponse<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = new Customers(request.CustomersNumber, request.FirstName, request.MiddleName, request.LastName, request.DateOfBirth, request.Gender, request.Email, request.PhoneNumber, request.Address, request.City, request.Province, request.PostalCode, request.EmergencyContactName, request.EmergencyNumber, request.Status);
                await _customerRepo.CreateCustomerAsync(customer);
                await _customerRepo.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "Customer added successfully.",
                    isSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>
                {
                    message = ex.Message,
                    isSuccess = false
                };
            }
        }
    }
}
