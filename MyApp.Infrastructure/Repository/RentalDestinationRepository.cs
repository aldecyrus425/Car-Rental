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
    public class RentalDestinationRepository : IRentalDestinationRepository
    {
        private readonly ApplicationDBContext _context;

        public RentalDestinationRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task CreateRentalDestination(RentalDestinations rentalDestination)
        {
            await _context.RentalDestinations.AddAsync(rentalDestination);
        }

        public async Task<RentalDestinations?> GetRentalDestinationAsync(Guid rentalDestinationId)
        {
            return await _context.RentalDestinations.FirstOrDefaultAsync(x => x.RentalDestinationId == rentalDestinationId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
