using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.VehicleType.Create
{
    public class CreateVehicleTypeHandler : IRequestHandler<CreateVehicleTypeCommand, GenericResponse<string>>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;

        public CreateVehicleTypeHandler(IVehicleTypeRepository vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        public async Task<GenericResponse<string>> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            var vehicleType = new VehicleTypes(request.Name, request.Description, request.SeatingCapacity, request.TransmissionType, request.FuelType, request.DailyBaseRate, request.IsActive);

            await _vehicleTypeRepository.CreateVehicleTypeAsync(vehicleType);
            return new GenericResponse<string>
            {
                message = "Vehicle type created successfully.",
                isSuccess = true,
            };
        }
    }
}
