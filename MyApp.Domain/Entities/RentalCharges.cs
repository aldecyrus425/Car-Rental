using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class RentalCharges
    {
        public Guid RentalChargeId { get; private set; }
        public Guid RentalId { get; private set; }
        public RentalAgreements Agreements { get; private set; }
        public string ChargeType { get; private set; }
        public string Description { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected RentalCharges() { }
    }
}
