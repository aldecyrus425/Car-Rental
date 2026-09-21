using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class RentalExtensions
    {
        public Guid RentalExtensionId { get; private set; }
        public Guid RentalId { get; private set; }
        public RentalAgreements Agreements { get; private set; }
        public DateTime PreviousReturnDateTime { get; private set; }
        public DateTime NewReturnDateTime { get; private set; }
        public int AdditionalDays { get; private set; }
        public decimal AdditionalAmount { get; private set; }
        public string Reason { get; private set; }
        public Guid ApprovedByUserId { get; private set; }
        public Users Users { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected RentalExtensions() { }

    }
}
