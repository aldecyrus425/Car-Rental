using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTOs
{
    public class RentalAgreementResponse
    {
        public Guid RentalAgreementId { get; set; }
        public string RentalNumber { get; set; } = string.Empty;

        public Guid CustomerId { get; set; }
        public Guid VehicleId { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime ExpectedReturnDateTime { get; set; }

        public string Status { get; set; } = string.Empty;

        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal AdditionalCharges { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
