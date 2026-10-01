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
    public class PricingAreaRepository : IPricingAreaRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public PricingAreaRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreatePricingAreaAsync(PricingAreas pricingArea)
        {
            await _dbContext.PricingAreas.AddAsync(pricingArea);
        }

        public async Task<IEnumerable<PricingAreas>> GetAllActivePricingAreaAsync()
        {
            return await _dbContext.PricingAreas.Where(pa => pa.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<PricingAreas>> GetAllPricingAreaAsync()
        {
            return await _dbContext.PricingAreas.ToListAsync();
        }

        public async Task<PricingAreas?> GetPricingAreaByIdAsync(Guid pricingAreaId)
        {
            return await _dbContext.PricingAreas.FirstOrDefaultAsync(x => x.PricingAreaId == pricingAreaId);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
