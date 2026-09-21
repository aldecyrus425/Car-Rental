using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class PricingAreas
    {
        public Guid PricingAreaId { get; private set; }
        public string Name { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string AreaType { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected PricingAreas() { }

        public ICollection<RentalDestinations> RentalDestinations { get; private set; } = new List<RentalDestinations>();
        public ICollection<PricingAreaRules> PricingAreaRules { get; private set; } = new List<PricingAreaRules>();
    }
}
