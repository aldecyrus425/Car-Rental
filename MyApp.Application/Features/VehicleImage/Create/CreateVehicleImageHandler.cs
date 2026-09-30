using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.FileStorage;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.VehicleImage.Create
{
    public class CreateVehicleImageHandler : IRequestHandler<CreateVehicleImageCommand, GenericResponse<string>>
    {
        private readonly IVehicleImagesRepository _vehicleImageRepo;
        private readonly IVehicleRepository _vehicleRepo;
        private readonly IFileStorageServices _storeImage;

        public CreateVehicleImageHandler(IVehicleImagesRepository vehicleImageRepo, IVehicleRepository vehicleRepo, IFileStorageServices storeImage)
        {
            _vehicleImageRepo = vehicleImageRepo;
            _vehicleRepo = vehicleRepo;
            _storeImage = storeImage;
        }

        public async Task<GenericResponse<string>> Handle(CreateVehicleImageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vehicleInformation = await _vehicleRepo.GetVehiclesByIdAsync(request.VehicleId);
                if(vehicleInformation == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "Vehicle information not found",
                        isSuccess = false
                    };
                }

                if(request.Images == null || request.Images.Count == 0)
                {
                    return new GenericResponse<string>
                    {
                        message = "No image provided.",
                        isSuccess = false
                    };
                }

                var folder = $"uploads/vehicles/{vehicleInformation.VehicleTypes.Name}/{request.VehicleId}";
                foreach (var file in request.Images)
                {

                    var extension = Path.GetExtension(file.ImageFile.FileName).ToLowerInvariant();
                    var filenName = $"{request.VehicleId}-{file.ImageType}{extension}";
                    await using var stream = file.ImageFile.OpenReadStream();
                    var filePath = await _storeImage.SaveAsync(stream, filenName, folder, cancellationToken);

                }

                return new GenericResponse<string>
                {
                    message = "Vehicle images uploaded successfully.",
                    isSuccess = true,
                    Data = folder
                };
            }
            catch(Exception ex)
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
