using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Customer.UpdateStatus
{
    public class UpdateStatusCustomerHandler : IRequestHandler<UpdateStatusCustomerCommand, GenericResponse<string>>
    {
        private readonly ICustomerRepository _customerRepo;
        public UpdateStatusCustomerHandler(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<GenericResponse<string>> Handle(UpdateStatusCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerRepo.GetCustomerByIdAsync(request.CustomerId);
                if(customer == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "Customer not found.",
                        isSuccess = false
                    };
                }

                customer.UpdateStatus(request.Status);
                await _customerRepo.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "Customer status updated successfully.",
                    isSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>
                {
                    message = $"Error updating customer status: {ex.Message}",
                    isSuccess = false,
                    Data = null
                };
            }
        }
    }
}
