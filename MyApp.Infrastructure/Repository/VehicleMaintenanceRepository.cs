using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repository
{
    public class VehicleMaintenanceRepository : IVehicleMaintenanceRepository
    {
        private readonly ApplicationDBContext _context;

        public VehicleMaintenanceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateVehicleMaintenanceAsync(VehicleMaintenance vehicleMaintenance)
        {
            await _context.VehicleMaintenance.AddAsync(vehicleMaintenance);
        }

        public async Task<IEnumerable<VehicleMaintenance>> GetAllMaintenanceVehiclesAsync()
        {
            return await _context.VehicleMaintenance.ToListAsync();
        }

        public async Task<VehicleMaintenance?> GetVehicleMaintenanceByIdAsync(Guid id)
        {
            return await _context.VehicleMaintenance.FirstOrDefaultAsync(x => x.MaintenanceId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
