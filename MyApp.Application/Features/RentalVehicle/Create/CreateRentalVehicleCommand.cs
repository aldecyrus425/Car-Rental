using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.RentalVehicle.Create
{
    public class CreateRentalVehicleCommand
    {
        public Guid VehicleId { get; set; }
        public decimal DailyRate { get; set; }
        public int NumberOfDays { get; set; }
    }
}
