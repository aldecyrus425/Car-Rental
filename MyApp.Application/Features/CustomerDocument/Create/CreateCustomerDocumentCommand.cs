using MediatR;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CustomerDocument.Create
{
    public class CreateCustomerDocumentCommand : IRequest<GenericResponse<string>>
    {
        public Guid CustomerId { get; set; }
        public string DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public bool IsVerified { get; set; }
        public Guid? VerifiedByUserId { get; set; }
        public string? Remarks { get; set; }
    }
}
