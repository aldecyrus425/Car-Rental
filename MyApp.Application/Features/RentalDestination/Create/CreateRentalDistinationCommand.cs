using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.RentalDestination.Create
{
    public class CreateRentalDistinationCommand
    {
        public Guid AreaId { get; set; }
        public string DestinationName { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public decimal? DistanceKm { get; set; }
        public string DestinationType { get; set; }
        public bool isPrimary { get; set; }
        public string? Remarks { get; set; }
    }
}
