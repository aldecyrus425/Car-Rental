using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IRentalVehicleRepository
    {
        Task CreateRentalVehicleAsync(RentalVehicles rentalVehicles);
        Task<RentalVehicles?> GetRentalVehicleAsync(Guid rentalVehicleId);
        Task SaveChangesAsync();
    }
}
