using MediatR;
using Microsoft.AspNetCore.Http;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.VehicleImage.Create
{
    public class CreateVehicleImageCommand : IRequest<GenericResponse<string>>
    {
        public Guid VehicleId { get; set; }
        public List<VehicleImageData> Images { get; set; } = new();
    }

    public class VehicleImageData
    {
        public IFormFile ImageFile { get; set; }
        public string ImageType { get; set; } // Front, Back, Side, Left, Right
        public bool IsPrimary { get; set; }
    }
}
