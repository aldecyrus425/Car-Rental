using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class VehicleInspections
    {
        public Guid InspectionId { get; private set; }
        public Guid RentalId { get; private set; }
        public RentalAgreements Agreements { get; private set; }
        public Guid  VehicleId { get; private set; }
        public Vehicles Vehicles { get; private set; }
        public string InspectionType { get; private set; }
        public DateTime InspectionDate {  get; private set; }
        public decimal Mileage { get; private set; }
        public decimal FuelLevel { get; private set; }
        public string OverallCondition { get; private set; }
        public string Remarks { get; private set; }
        public Guid InspectedByUserId { get; private set; }
        public Users Users { get; private set; }

        protected VehicleInspections() { }
    }
}
