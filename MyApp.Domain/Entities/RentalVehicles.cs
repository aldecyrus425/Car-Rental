using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class RentalVehicles
    {
        public Guid RentalVehicleId { get; private set; }
        public Guid RentalId { get; private set; }
        public RentalAgreements Agreements { get; private set; }
        public Guid VehicleId { get; private set; }
        public Vehicles Vehicles { get; private set; }
        public decimal DailyRate { get; private set; }
        public int NumberOfDays { get; private set; }
        public decimal SubTotal { get; private set; }

        protected RentalVehicles() { }
    }
}
