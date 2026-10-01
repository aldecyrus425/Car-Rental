using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.PricingAreaRule.Create
{
    public class CreatePricingAreaRuleHandler : IRequestHandler<CreatePricingAreaRuleCommand, GenericResponse<string>>
    {
        private readonly IPricingAreaRuleRepository _pricingAreaRuleRepo;
        private readonly IPricingAreaRepository _pricingAreaRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepo;
        public CreatePricingAreaRuleHandler(IPricingAreaRuleRepository pricingAreaRuleRepo, IPricingAreaRepository pricingAreaRepository, IVehicleTypeRepository vehicleTypeRepository)
        {
            _pricingAreaRuleRepo = pricingAreaRuleRepo;
            _pricingAreaRepository = pricingAreaRepository;
            _vehicleTypeRepo = vehicleTypeRepository;
        }

        public async Task<GenericResponse<string>> Handle(CreatePricingAreaRuleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pricingAreaInformation = await _pricingAreaRepository.GetPricingAreaByIdAsync(request.PricingAreaId);
                if ( pricingAreaInformation == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "Pricing area not found",
                        isSuccess = false
                    };
                }

                if(request.VehicleTypeId != null)
                {
                    var vehicleTypeInformation = await _vehicleTypeRepo.GetVehicleTypeByIdAsync(request.VehicleTypeId.Value);
                    if( vehicleTypeInformation == null)
                    {
                        return new GenericResponse<string>
                        {
                            message = "Vehicle type not found.",
                            isSuccess = false
                        };
                    }
                }


                var pricingAreaRule = new PricingAreaRules(request.PricingAreaId, request.VehicleTypeId, request.PricingType, request.Amount, request.MinimumDays, request.MaximumDays, request.EffectiveFrom, request.EffectiveTo, request.IsActive);
                await _pricingAreaRuleRepo.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "Pricing area rule added successfully.",
                    isSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>
                {
                    message = ex.Message,
                    isSuccess = true,
                };
            }
        }
    }
}
