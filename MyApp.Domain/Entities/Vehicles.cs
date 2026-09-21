using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Vehicles
    {
        public Guid VehicleId { get; private set; }
        public Guid VehicleTypeId { get; private set; }
        public VehicleTypes VehicleTypes { get; private set; }

        public string PlateNumber { get; private set; }
        public string VehicleCode { get; private set; }
        public string? VIN { get; private set; }
        public string Make { get; private set; } // Toyota, Honda, Ford, etc.
        public string Model { get; private set; } // Camry, Civic, F-150, etc.
        public int Year { get; private set; } // 2020, 2021, etc.
        public string Color { get; private set; } // Red, Blue, Black, etc.
        public decimal CurrentMileage { get; private set; } // 10000.5, 20000.0, etc.
        public decimal FuelLevel { get; private set; } // 0.5, 0.75, 1.0, etc.
        public string Status { get; private set; } // Available, In Use, Maintenance, etc.
        public DateOnly? RegistrationExpiryDate { get; private set; } // 2023-12-31, 2024-06-30, etc.
        public DateOnly? InsuranceExpiryDate { get; private set; } // 2023-12-31, 2024-06-30, etc.}
        public Guid BranchId { get; private set; } // Foreign key to Branches table
        public Branches Branch { get; private set; } // Navigation property to Branches table
        public DateTime CreatedAt { get; private set; } // Timestamp of when the vehicle was added to the system
        public DateTime? UpdatedAt { get; private set; } // Timestamp of when the vehicle was last updated in the system

        protected Vehicles() { }

        public ICollection<VehicleImages> VehicleImages { get; private set; } = new List<VehicleImages>(); // Navigation property for related vehicle images>

        public ICollection<RentalVehicles> RentalVehicle { get; private set; } = new List<RentalVehicles>();
        public ICollection<DamageReports> DamageReport = new List<DamageReports>();
        public ICollection<VehicleMaintenance> VehicleMaintenance { get; private set; } = new List<VehicleMaintenance>();

    }
}
