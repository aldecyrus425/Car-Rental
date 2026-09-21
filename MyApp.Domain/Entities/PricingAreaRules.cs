using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class PricingAreaRules
    {
        public Guid PricingAreaRuleId { get; private set; }
        public Guid PricingAreaId { get; private set; }
        public PricingAreas PricingAreas { get; private set; }
        public Guid? VehicleTypeId { get; private set; }
        public VehicleTypes VehicleTypes { get; private set; }
        public string PricingType { get; private set; }
        public decimal Amount { get; private set; }
        public int? MinimumDays { get; private set; }
        public int? MaximumDays { get; private set; }
        public DateOnly EffectiveFrom {  get; private set; }
        public DateOnly? EffectiveTo { get; private set; }
        public bool IsActive { get; private set; }

        protected PricingAreaRules() { }
    }
}
