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
    public class RentalVehicleRepository : IRentalVehicleRepository
    {
        private readonly ApplicationDBContext _context;

        public RentalVehicleRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateRentalVehicleAsync(RentalVehicles rentalVehicles)
        {
            await _context.RentalVehicles.AddAsync(rentalVehicles);
        }

        public async Task<RentalVehicles?> GetRentalVehicleAsync(Guid rentalVehicleId)
        {
            return await _context.RentalVehicles.FirstOrDefaultAsync(x => x.RentalVehicleId == rentalVehicleId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
