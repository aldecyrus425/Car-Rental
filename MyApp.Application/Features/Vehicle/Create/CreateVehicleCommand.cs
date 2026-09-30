using MediatR;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Vehicle.Create
{
    public class CreateVehicleCommand : IRequest<GenericResponse<string>>
    {
        public Guid VehicleTypeId { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleCode { get; set; }
        public string? VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal CurrentMileage { get; set; }
        public decimal FuelLevel { get; set; }
        public string Status { get; set; }
        public DateOnly? RegistrationExpiryDate { get; set; }
        public DateOnly? InsuranceExpiryDate { get; set; }
        public Guid BranchId { get; set; }
    }
}
