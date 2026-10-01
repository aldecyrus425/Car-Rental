using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class RentalAgreements
    {
        public Guid RentalAgreementId { get; private set; }
        public string RentalNumber { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customers Customer { get; private set; }
        public Guid BranchId { get; private set; }
        public Branches Branches { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime ExpectedReturnDateTime { get; private set; }
        public DateTime? ActualReturnDateTime { get; private set; }
        public string Status { get; private set; }
        public string RentalType { get; private set; }
        public string PickupLocation { get; private set; }
        public string ReturnLocation { get; private set; }
        public decimal StartingMileage { get; private set; }
        public decimal? EndingMileage { get; private set; }
        public decimal StartingFuelLevel { get; private set; }
        public decimal? EndingFuelLevel { get; private set; }
        public decimal SubTotal { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public decimal PenaltyAmount { get; private set; }
        public decimal AdditionalCharges {  get; private set; }
        public decimal TotalAmount { get; private set; }
        public decimal DepositAmount { get; private set; }
        public Guid CreatedBy { get; private set; }
        public Users Users { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        protected RentalAgreements() { }

        public ICollection<RentalVehicles> RentalVehicle { get; private set; } = new List<RentalVehicles>();
        public ICollection<RentalDestinations> RentalDestinations { get; private set; } = new List<RentalDestinations>();
        public ICollection<RentalCharges> RentalCharges { get; private set; } = new List<RentalCharges>();
        public ICollection<RentalDocuments> RentalDocuments { get; private set; } = new List<RentalDocuments>();
        public ICollection<Payments> Payments { get; private set; } = new List<Payments>();
        public ICollection<RentalExtensions> RentalExtensions = new List<RentalExtensions>();
        public ICollection<VehicleInspections> VehicleInspections { get; private set; } = new List<VehicleInspections>();
        public ICollection<DamageReports> DamageReport = new List<DamageReports>();
        public ICollection<AdditionalCharges> AdditionalCharge { get; private set; } = new List<AdditionalCharges>();

        public RentalAgreements(string rentalNumber, Guid customerId, Guid branchId, DateTime startDateTime, DateTime expectedReturnDateTime, string status, string rentalType, string pickupLocation, string returnLocation, decimal startingMileage, decimal startingFuelLevel, decimal subTotal, decimal discountAmount, decimal penaltyAmount, decimal additionalCharges, decimal totalAmount, decimal depositAmount, Guid createdBy)
        {
            RentalAgreementId = Guid.NewGuid();
            RentalNumber = rentalNumber;
            CustomerId = customerId;
            BranchId = branchId;
            StartDateTime = startDateTime;
            ExpectedReturnDateTime = expectedReturnDateTime;
            Status = status;
            RentalType = rentalType;
            PickupLocation = pickupLocation;
            ReturnLocation = returnLocation;
            StartingMileage = startingMileage;
            StartingFuelLevel = startingFuelLevel;
            SubTotal = subTotal;
            DiscountAmount = discountAmount;
            PenaltyAmount = penaltyAmount;
            AdditionalCharges = additionalCharges;
            TotalAmount = totalAmount;
            DepositAmount = depositAmount;
            CreatedBy = createdBy;
            CreatedAt = DateTime.UtcNow;
        }

        public void ActualReturnDate()
        {
            ActualReturnDateTime = DateTime.Now;
        }
    }
}
