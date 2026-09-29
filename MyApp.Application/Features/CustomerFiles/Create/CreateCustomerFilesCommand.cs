using MediatR;
using Microsoft.AspNetCore.Http;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CustomerFiles.Create
{
    public class CreateCustomerFilesCommand : IRequest<GenericResponse<string>>
    {
        public Guid CustomerDocumentId { get; set; }
        public List<IFormFile> Files { get; set; } = new();
    }
}
