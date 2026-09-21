using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Payments
    {
        public Guid PaymentsId { get; private set; }
        public Guid RentalId { get; private set; }
        public RentalAgreements Agreements { get; private set; }
        public string PaymentNumber { get; private set; }
        public decimal Amount { get; private set; }
        public string PaymentMethod { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public string? ReferenceNumber { get; private set; }
        public Guid ReceivedByUserId { get; private set; }
        public Users Users { get; private set; }
        public string? Remarks {  get; private set; }

        protected Payments() { }
        
    }
}
