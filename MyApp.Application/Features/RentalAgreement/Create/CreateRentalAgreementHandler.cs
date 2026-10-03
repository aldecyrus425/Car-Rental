using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces;
using MyApp.Application.Interfaces.FileStorage;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.RentalAgreement.Create
{
    public class CreateRentalAgreementHandler : IRequestHandler<CreateRentalAgreementCommand, GenericResponse<string>>
    {
        private readonly IRentalAgreementRepository _rentalAgreementRepo;
        private readonly IRentalDestinationRepository _rentalDestinationRepo;
        private readonly IRentalVehicleRepository _rentalVehicleRepo;
        private readonly IRentalDocumentRepository _rentalDocumentRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IBranchRepository _branchRepo;
        private readonly IUserRepository _userRepo;
        private readonly IVehicleRepository _vehicleRepo;
        private readonly IFileStorageServices _storageService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRentalAgreementHandler(IRentalAgreementRepository rentalAgreementRepo,IRentalDestinationRepository rentalDestinationRepo, IRentalVehicleRepository rentalVehicleRepo, IRentalDocumentRepository rentalDocumentRepo, ICustomerRepository customerRepo, IBranchRepository branchRepo, IUserRepository userRepo, IFileStorageServices storageService, IVehicleRepository vehicleRepo, IUnitOfWork unitOfWork)
        {
            _rentalAgreementRepo = rentalAgreementRepo;
            _rentalDestinationRepo = rentalDestinationRepo;
            _rentalVehicleRepo = rentalVehicleRepo;
            _rentalDocumentRepo = rentalDocumentRepo;
            _customerRepo = customerRepo;
            _branchRepo = branchRepo;
            _userRepo = userRepo;
            _storageService = storageService;
            _vehicleRepo = vehicleRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<GenericResponse<string>> Handle(CreateRentalAgreementCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            var savedFile = new List<string>();
            try
            {
                var customer = await _customerRepo.GetCustomerByIdAsync(request.CustomerId);
                if (customer == null || customer.Status != "Active")
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return new GenericResponse<string>
                    {
                        message = "Customer not found or inactive.",
                        isSuccess = false
                    };
                }

                var branch = await _branchRepo.GetBranchByIdAsync(request.BranchId);
                if (branch == null || !branch.IsActive)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return new GenericResponse<string>
                    {
                        message = "Branch not found or inactive.",
                        isSuccess = false
                    };
                }

                var user = await _userRepo.GetUserByIdAsync(request.CreatedBy);
                if (user == null || !user.IsActive)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return new GenericResponse<string>
                    {
                        message = "User not found or inactive.",
                        isSuccess = false
                    };
                }

                var vehicle = await _vehicleRepo.GetVehiclesByIdAsync(request.RentalVehicle.VehicleId);
                if (vehicle == null || vehicle.Status != "Available")
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return new GenericResponse<string>
                    {
                        message = "Vehicle is not available for rental.",
                        isSuccess = false
                    };
                }


                var rentalAgreement = new RentalAgreements(request.RentalNumber, customer.CustomerId, branch.BranchId, request.StartDateTime, request.ExpectedReturnDateTime, request.Status, request.RentalType, request.PickupLocation, request.ReturnLocation, request.StartingMileage, request.StartingFuelLevel, request.SubTotal, request.DiscountAmount, request.TotalAmount, request.PenaltyAmount, request.AdditionalCharges, request.DepositAmount, user.UserId);
                var rentalDestination = new RentalDestinations(rentalAgreement.RentalAgreementId, request.RentalDestination.AreaId, request.RentalDestination.DestinationName, request.RentalDestination.City, request.RentalDestination.Province, request.RentalDestination.DistanceKm, request.RentalDestination.DestinationType, request.RentalDestination.isPrimary, request.RentalDestination.Remarks);
                var rentalVehicles = new RentalVehicles(rentalAgreement.RentalAgreementId, request.RentalVehicle.VehicleId, request.RentalVehicle.DailyRate, request.RentalVehicle.NumberOfDays);

                await _rentalAgreementRepo.CreateAgreementAsync(rentalAgreement);

                await _rentalDestinationRepo.CreateRentalDestination(rentalDestination);

                await _rentalVehicleRepo.CreateRentalVehicleAsync(rentalVehicles);

                var folder = $"uploads/rental-documents/{request.RentalVehicle.VehicleId}";
                var filePath = "";
                foreach(var file in request.RentalDocuments)
                {
                    var extension = Path.GetExtension(file.Documents.FileName).ToLowerInvariant();
                    var fileName = $"{rentalAgreement.RentalAgreementId}-{customer.CustomerId}-{Guid.NewGuid()}{extension}";
                    await using var stream = file.Documents.OpenReadStream();
                    filePath = await _storageService.SaveAsync(stream, fileName, folder, cancellationToken);
                    
                    savedFile.Add(filePath);

                    var rentalDocument = new RentalDocuments(rentalAgreement.RentalAgreementId, file.DocumentType, filePath, fileName, file.MimeType, user.UserId);
                    await _rentalDocumentRepo.CreateRentalDocumentAsync(rentalDocument);
                }
                
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return new GenericResponse<string>
                {
                    message = "Rental Agreement created successfully.",
                    isSuccess = true,
                    Data = filePath
                };
            }
            catch (Exception ex)
            {
                foreach (var file in savedFile)
                {
                    try
                    {
                        await _storageService.DeleteAsync(file, cancellationToken);

                    }
                    catch (Exception deleteEx)
                    {
                        Console.WriteLine($"Failed to delete file {file}: {deleteEx.Message}");
                    }
                }

                await _unitOfWork.RollbackTransactionAsync();


                return new GenericResponse<string>
                {
                    message = ex.Message,
                    isSuccess = false,
                };
            }
        }
    }
}
