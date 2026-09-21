using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class AdditionalCharges
    {
        public Guid AdditionalChargeId { get; private set; }
        public Guid RentalId { get; private set; }
        public RentalAgreements Agreement { get; private set; }
        public string ChargeType { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public Guid CreatedByUserId { get; private set; }
        public Users Users { get; private set; }
        public DateTime CreatedAt { get; private set; }
        protected AdditionalCharges() { }
    }
}
