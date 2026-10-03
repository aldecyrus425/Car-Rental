using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class RentalDestinations
    {

        public Guid RentalDestinationId { get; private set; }
        public Guid RentalId { get; private set; }
        public RentalAgreements RentalAgreement { get; private set; }
        public Guid AreaId { get; private set; }
        public PricingAreas PricingAreas { get; private set; }
        public string DestinationName { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public decimal? DistanceKm { get; private set; }
        public string DestinationType { get; private set; }
        public bool IsPrimary { get; private set; }
        public string? Remarks { get; private set; }

        protected RentalDestinations() { }
        public RentalDestinations(Guid rentalId, Guid areaId, string destinationName, string city, string province, decimal? distanceKm, string destinationType, bool isPrimary, string? remarks)
        {
            RentalDestinationId = Guid.NewGuid();
            RentalId = rentalId;
            AreaId = areaId;
            DestinationName = destinationName;
            City = city;
            Province = province;
            DistanceKm = distanceKm;
            DestinationType = destinationType;
            IsPrimary = isPrimary;
            Remarks = remarks;
        }
    }
}
