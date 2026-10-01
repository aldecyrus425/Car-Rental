using MediatR;
using MyApp.Application.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.MaintenanceVehicle.Create
{
    public class CreateMaintenanceVehicleCommand : IRequest<GenericResponse<string>>
    {
        public Guid VehicleId { get; set; }
        public string MaintenanceType { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public decimal Mileage { get; set; }
        public decimal Cost { get; set; }
        public string Status { get; set; }
        public string? ServiceProvider { get; set; }
        public string? Remarks { get; set; }
        public Guid CreateByUserId { get; set; }
    }
}
