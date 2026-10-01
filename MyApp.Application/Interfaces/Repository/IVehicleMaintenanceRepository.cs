using MyApp.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IVehicleMaintenanceRepository
    {
        Task CreateVehicleMaintenanceAsync(VehicleMaintenance vehicleMaintenance);
        Task<IEnumerable<VehicleMaintenance>> GetAllMaintenanceVehiclesAsync();
        Task<VehicleMaintenance?> GetVehicleMaintenanceByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
