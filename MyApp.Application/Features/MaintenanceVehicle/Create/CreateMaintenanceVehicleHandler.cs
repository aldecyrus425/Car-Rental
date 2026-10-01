using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.MaintenanceVehicle.Create
{
    public class CreateMaintenanceVehicleHandler : IRequestHandler<CreateMaintenanceVehicleCommand, GenericResponse<string>>
    {
        private readonly IVehicleMaintenanceRepository _vehicleMaintenanceRepo;
        private readonly IVehicleRepository _vehicleRepo;

        public CreateMaintenanceVehicleHandler(IVehicleMaintenanceRepository vehicleMaintenanceRepo, IVehicleRepository vehicleRepo)
        {
            _vehicleMaintenanceRepo = vehicleMaintenanceRepo;
            _vehicleRepo = vehicleRepo;
        }

        public async Task<GenericResponse<string>> Handle(CreateMaintenanceVehicleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vehicleInformation = await _vehicleRepo.GetVehiclesByIdAsync(request.VehicleId);
                if (vehicleInformation == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "Vehicle not found",
                        isSuccess = false
                    };
                }


                var vehicleMaintenance = new VehicleMaintenance(request.VehicleId, request.MaintenanceType, request.Description, request.StartDate, request.Mileage, request.Cost, request.Status, request.ServiceProvider, request.Remarks, request.CreateByUserId);
                await _vehicleMaintenanceRepo.CreateVehicleMaintenanceAsync(vehicleMaintenance);

                await _vehicleMaintenanceRepo.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "Vehicle maintenance added successfully.",
                    isSuccess = true,
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
