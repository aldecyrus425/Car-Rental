using MediatR;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.VehicleType.Create
{
    public class CreateVehicleTypeCommand : IRequest<GenericResponse<string>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int SeatingCapacity { get; set; }
        public string TransmissionType { get; set; }
        public string FuelType { get; set; }
        public decimal DailyBaseRate { get; set; }
        public bool IsActive { get; set; }
    }
}
