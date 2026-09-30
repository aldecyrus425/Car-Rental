using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Vehicle.Create
{
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, GenericResponse<string>>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public CreateVehicleHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<GenericResponse<string>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vehicle = new Vehicles(
                    request.VehicleTypeId,
                    request.PlateNumber,
                    request.VehicleCode,
                    request.VIN,
                    request.Make,
                    request.Model,
                    request.Year,
                    request.Color,
                    request.CurrentMileage,
                    request.FuelLevel,
                    request.Status,
                    request.RegistrationExpiryDate,
                    request.InsuranceExpiryDate,
                    request.BranchId);

                await _vehicleRepository.CreateVehicleAsync(vehicle);
                await _vehicleRepository.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "Vehicle created successfully.",
                    isSuccess = true,
                    Data = vehicle.VehicleId.ToString()
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>
                {
                    message = $"An error occurred while creating the vehicle: {ex.Message}",
                    isSuccess = false,
                    Data = null
                };
            }
        }
    }
}
