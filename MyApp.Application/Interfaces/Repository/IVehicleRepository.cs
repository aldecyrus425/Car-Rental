using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IVehicleRepository
    {
        Task CreateVehicleAsync(Vehicles vehicles);
        Task<Vehicles?> GetVehiclesByIdAsync(Guid Id);
        Task<IEnumerable<Vehicles>> GetAllVehiclesAsync();
        Task<IEnumerable<Vehicles>> GetAllVehiclesAccordingStatusAsync(string status);
        Task<IEnumerable<Vehicles>> GetAllVehiclesAccordingTypesAsync(Guid typeId);
        Task SaveChangesAsync();
    }
}
