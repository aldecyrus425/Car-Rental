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

        public VehicleMaintenance(Guid vehicleId, string maintenanceType, string description, DateTime startDate, decimal mileage, decimal cost, string status, string? serviceProvider, string? remarks, Guid createByUserId)
        {
            MaintenanceId = Guid.NewGuid();
            VehicleId = vehicleId;
            MaintenanceType = maintenanceType;
            Description = description;
            StartDate = startDate;
            Mileage = mileage;
            Cost = cost;
            Status = status;
            ServiceProvider = serviceProvider;
            Remarks = remarks;
            CreateByUserId = createByUserId;
        }

        public void MaintenanceComplete()
        {
            CompletionDate = DateTime.UtcNow;
            Status = "Completed";
        }
    }
}
