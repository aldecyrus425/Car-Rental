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
    public class VehicleTypesRepository : IVehicleTypeRepository
    {
        private readonly ApplicationDBContext _context;

        public VehicleTypesRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateVehicleTypeAsync(VehicleTypes vehicleTypes)
        {
            await _context.VehicleTypes.AddAsync(vehicleTypes);
        }

        public async Task<IEnumerable<VehicleTypes>> GetAllActiveVehicleTypesAsync()
        {
            return await _context.VehicleTypes.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<VehicleTypes>> GetAllVehicleTypesAsync()
        {
            return await _context.VehicleTypes.ToListAsync();
        }

        public async Task<VehicleTypes?> GetVehicleTypeByIdAsync(Guid vehicleTypeId)
        {
            return await _context.VehicleTypes.FirstOrDefaultAsync(x => x.VehicleTypeId == vehicleTypeId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
