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
    public class VehicleRepository : IVehicleRepository
    {

        private readonly ApplicationDBContext _context;

        public VehicleRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateVehicleAsync(Vehicles vehicles)
        {
            await _context.Vehicles.AddAsync(vehicles);
        }

        public async Task<IEnumerable<Vehicles>> GetAllVehiclesAccordingStatusAsync(string status)
        {
            return await _context.Vehicles.Where(x => x.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<Vehicles>> GetAllVehiclesAccordingTypesAsync(Guid typeId)
        {
            return await _context.Vehicles.Where(x => x.VehicleTypeId == typeId).ToListAsync();
        }

        public async Task<IEnumerable<Vehicles>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicles?> GetVehiclesByIdAsync(Guid Id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(x => x.VehicleTypeId == Id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
