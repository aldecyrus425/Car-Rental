using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IVehicleTypeRepository
    {
        Task CreateVehicleTypeAsync(VehicleTypes vehicleTypes);
        Task<VehicleTypes?> GetVehicleTypeByIdAsync(Guid vehicleTypeId);
        Task<IEnumerable<VehicleTypes>> GetAllVehicleTypesAsync();
        Task<IEnumerable<VehicleTypes>> GetAllActiveVehicleTypesAsync();
        Task SaveChangesAsync();
    }
}
