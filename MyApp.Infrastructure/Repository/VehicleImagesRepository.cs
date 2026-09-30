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
    public class VehicleImagesRepository : IVehicleImagesRepository
    {
        private readonly ApplicationDBContext _context;

        public VehicleImagesRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task CreateVehicleImageAsync(VehicleImages images)
        {
            await _context.VehicleImages.AddAsync(images);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
