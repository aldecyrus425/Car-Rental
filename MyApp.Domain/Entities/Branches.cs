using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Branches
    {
        public Guid BranchId { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string ContactNumber { get; private set; }
        public bool IsActive { get; private set; }

        public ICollection<Vehicles> Vehicles { get; private set; } = new List<Vehicles>(); // Navigation property for related vehicles
    }
}
