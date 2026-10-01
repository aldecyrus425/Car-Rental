using MediatR;
using MyApp.Application.DTOs;
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
        private readonly ICustomerRepository _customerRepo;
        private readonly IBranchRepository _branchRepo;
        private readonly IUserRepository _userRepo;

        public CreateRentalAgreementHandler(IRentalAgreementRepository rentalAgreementRepo, ICustomerRepository customerRepo, IBranchRepository branchRepo, IUserRepository userRepo)
        {
            _rentalAgreementRepo = rentalAgreementRepo;
            _customerRepo = customerRepo;
            _branchRepo = branchRepo;
            _userRepo = userRepo;
        }

        public async Task<GenericResponse<string>> Handle(CreateRentalAgreementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var activeUser = await _userRepo.GetActiveUserById(request.CreatedBy);
                if(activeUser == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "User inactive or not existing.",
                        isSuccess = false
                    };
                }

                if(await _customerRepo.GetCustomerByIdAsync(request.CustomerId) == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "Customer not existing.",
                        isSuccess = false
                    };
                }

                if(await _branchRepo.GetBranchByIdAsync(request.BranchId) == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "Branch not existing.",
                        isSuccess = false
                    };
                }

                var rentalAgreement = new RentalAgreements(
                    request.RentalNumber, 
                    request.CustomerId, 
                    request.BranchId, 
                    request.StartDateTime, 
                    request.ExpectedReturnDateTime,
                    request.Status,
                    request.RentalType,
                    request.PickupLocation,
                    request.ReturnLocation,
                    request.StartingMileage,
                    request.StartingFuelLevel,
                    request.SubTotal,
                    request.DiscountAmount,
                    request.TotalAmount,
                    request.PenaltyAmount,
                    request.AdditionalCharges,
                    request.DepositAmount,
                    request.CreatedBy);

                await _rentalAgreementRepo.CreateAgreementAsync(rentalAgreement);
                await _rentalAgreementRepo.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "Rental Agreement created successfully.",
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
