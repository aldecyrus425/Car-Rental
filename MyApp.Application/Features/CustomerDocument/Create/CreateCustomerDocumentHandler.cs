using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CustomerDocument.Create
{
    public class CreateCustomerDocumentHandler : IRequestHandler<CreateCustomerDocumentCommand, GenericResponse<string>>
    {
        private readonly ICustomerDocumentsRepository _customerDocumentRepository;

        public CreateCustomerDocumentHandler(ICustomerDocumentsRepository customerDocumentRepository)
        {
            _customerDocumentRepository = customerDocumentRepository;
        }


        public async Task<GenericResponse<string>> Handle(CreateCustomerDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customerDocument = new CustomerDocuments(request.CustomerId, request.DocumentType, request.DocumentNumber, request.ExpirationDate, request.IsVerified, request.VerifiedByUserId, request.Remarks);
                await _customerDocumentRepository.CreateDocumentAsync(customerDocument);
                await _customerDocumentRepository.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "Customer document created successfully.",
                    isSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>
                {
                    message = $"An error occurred while creating the customer document: {ex.Message}",
                    isSuccess = false,
                    Data = null
                };
            }
        }
    }
}
