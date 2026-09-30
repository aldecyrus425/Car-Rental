using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.FileStorage;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CustomerFiles.Create
{
    public class CreateCustomerFilesHandler : IRequestHandler<CreateCustomerFilesCommand, GenericResponse<string>>
    {
        private readonly ICustomerFilesRepository _customerFileRepo;
        private readonly ICustomerDocumentsRepository _customerDocuRepo;
        private readonly IFileStorageServices _storeImage;

        public CreateCustomerFilesHandler(ICustomerFilesRepository customerFileRepo,  ICustomerDocumentsRepository customerDocuRepo, IFileStorageServices storeImage)
        {
            _customerFileRepo = customerFileRepo;   
            _customerDocuRepo = customerDocuRepo;
            _storeImage = storeImage;
        }
        public async Task<GenericResponse<string>> Handle(CreateCustomerFilesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customerDocument = await _customerDocuRepo.GetCustomerDocumentIdAsync(request.CustomerDocumentId);
                if(customerDocument == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "Customer document not found.",
                        isSuccess = false
                    };
                }

                if (request.Files == null || request.Files.Count == 0)
                {
                    return new GenericResponse<string>
                    {
                        message = "No files were provided.",
                        isSuccess = false
                    };
                }

                var folder = $"uploads/customers/{customerDocument.CustomerDocumentId}/{customerDocument.DocumentType}";


                var count = 1;
                foreach (var file in request.Files)
                {
                    if (file.Length == 0)
                    {
                        continue;
                    }

                    var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

                    var fileName = $"{customerDocument.Customer.CustomerId}-{count}{extension}";


                    await using var stream = file.OpenReadStream();

                    var filePath = await _storeImage.SaveAsync( stream, fileName, folder, cancellationToken);

                    count++;
                }

                return new GenericResponse<string>
                {
                    message = "Customer files uploaded successfully.",
                    isSuccess = true,
                    Data = folder
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
