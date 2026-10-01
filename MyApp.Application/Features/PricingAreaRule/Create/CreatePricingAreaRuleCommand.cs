using MediatR;
using MyApp.Application.DTOs;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.PricingAreaRule.Create
{
    public class CreatePricingAreaRuleCommand : IRequest<GenericResponse<string>>
    {
        public Guid PricingAreaId { get; set; }
        public Guid? VehicleTypeId { get; set; }
        public string PricingType { get; set; }
        public decimal Amount { get; set; }
        public int? MinimumDays { get; set; }
        public int? MaximumDays { get; set; }
        public DateOnly EffectiveFrom { get; set; }
        public DateOnly? EffectiveTo { get; set; }
        public bool IsActive { get; set; }
    }
}
