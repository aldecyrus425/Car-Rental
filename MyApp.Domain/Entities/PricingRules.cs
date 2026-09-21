using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class PricingRules
    {
        public Guid PricingRulesId { get; private set; }
        public Guid VehicleTypeId { get; private set; }
        public VehicleTypes VehicleTypes { get; private set; }
        public string PricingType { get; private set; }
        public decimal Rate { get; private set; }
        public int? MinimumDays { get; private set; }
        public int? MaximumDays { get; private set; }
        public DateOnly Effectivefrom { get; private set; }
        public DateOnly? EffectiveTo { get; private set; }
        public bool IsActive { get; private set; }

        protected PricingRules() { }
    }
}
