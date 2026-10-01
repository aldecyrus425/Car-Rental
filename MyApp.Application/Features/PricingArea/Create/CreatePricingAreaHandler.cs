using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.PricingArea.Create
{
    public class CreatePricingAreaHandler : IRequestHandler<CreatePricingAreaCommand, GenericResponse<string>>
    {
        private readonly IPricingAreaRepository _pricingAreaRepo;

        public CreatePricingAreaHandler(IPricingAreaRepository pricingAreaRepo)
        {
            _pricingAreaRepo = pricingAreaRepo;
        }

        public async Task<GenericResponse<string>> Handle(CreatePricingAreaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pricingArea = new PricingAreas(request.Name, request.City, request.Province, request.AreaType, request.IsActive);
                await _pricingAreaRepo.CreatePricingAreaAsync(pricingArea);
                await _pricingAreaRepo.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "Pricing area created successfully.",
                    isSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>
                {
                    message = $"An error occurred while creating the pricing area: {ex.Message}",
                    isSuccess = false,
                };
            }
        }
    }
}
