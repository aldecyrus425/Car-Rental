using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Customer.Update
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, GenericResponse<string>>
    {
        private readonly ICustomerRepository _customerRepo;

        public UpdateCustomerHandler(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<GenericResponse<string>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerRepo.GetCustomerByIdAsync(request.CustomerId);
                if(customer == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "Customer not found.",
                        isSuccess = false,
                    };
                }

                customer.UpdateCustomers(request.FirstName, request.MiddleName, request.LastName, request.DateOfBirth, request.Gender, request.Email, request.PhoneNumber, request.Address, request.City, request.Province, request.PostalCode, request.EmergencyContactName, request.EmergencyNumber);
                await _customerRepo.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "Customer updated successfully.",
                    isSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>
                {
                    message = $"An error occurred while updating the customer: {ex.Message}",
                    isSuccess = false,
                };
            }
        }
    }
}
