using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IRentalDestinationRepository
    {
        Task CreateRentalDestination(RentalDestinations rentalDestination);
        Task<RentalDestinations?> GetRentalDestinationAsync(Guid rentalDestinationId);
        Task SaveChangesAsync();
    }
}
