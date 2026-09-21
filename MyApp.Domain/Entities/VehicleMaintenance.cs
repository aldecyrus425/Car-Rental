using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class VehicleMaintenance
    {
        public Guid MaintenanceId { get; private set; }
        public Guid VehicleId { get; private set; }
        public Vehicles Vehicles { get; private set; }
        public string MaintenanceType { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? CompletionDate {  get; private set; }
        public decimal Mileage { get; private set; }
        public decimal Cost { get; private set; }
        public string Status { get; private set; }
        public string? ServiceProvider { get; private set; }
        public string? Remarks { get; private set; }
        public Guid CreateByUserId { get; private set; }
        public Users Users { get; private set; }

        protected VehicleMaintenance() { }
    }
}
