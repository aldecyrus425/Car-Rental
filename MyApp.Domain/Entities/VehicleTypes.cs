using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class VehicleTypes
    {
        public Guid VehicleTypeId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public int SeatingCapacity { get; private set; }
        public string TransmissionType { get; private set; } // Manual, Automatic, Semi-Automatic
        public string FuelType { get; private set; } // Petrol, Diesel, Electric, Hybrid
        public decimal DailyBaseRate { get; private set; }
        public bool IsActive { get; private set; }

        public ICollection<Vehicles> Vehicles { get; private set; } = new List<Vehicles>();
    }
}
