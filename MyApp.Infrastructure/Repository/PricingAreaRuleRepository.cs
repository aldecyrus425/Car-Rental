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
    public class PricingAreaRuleRepository : IPricingAreaRuleRepository
    {
        private readonly ApplicationDBContext _context;

        public PricingAreaRuleRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreatePricingAreaRuleAsync(PricingAreaRules pricingAreaRule)
        {
            await _context.PricingAreasRules.AddAsync(pricingAreaRule);
        }

        public async Task<IEnumerable<PricingAreaRules>> GetAllActivePricingAreaRuleAsync()
        {
            return await _context.PricingAreasRules.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<PricingAreaRules>> GetAllPricingAreaRulesAsync()
        {
            return await _context.PricingAreasRules.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
