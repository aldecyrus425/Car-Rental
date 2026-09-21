using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class VehicleImages
    {
        public Guid VehicleImageId { get; private set; }
        public Guid VehicleId { get; private set; }
        public Vehicles Vehicle { get; private set; }
        public string FilePath { get; private set; }
        public string ImageType { get; private set; } // e.g., "Front", "Side", "Rear"
        public string FileName { get; private set; }
        public bool IsPrimary { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected VehicleImages() { }

    }
}
