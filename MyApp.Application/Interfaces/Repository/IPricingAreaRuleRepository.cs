using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IPricingAreaRuleRepository
    {
        Task CreatePricingAreaRuleAsync(PricingAreaRules pricingAreaRule);
        Task<IEnumerable<PricingAreaRules>> GetAllPricingAreaRulesAsync();
        Task<IEnumerable<PricingAreaRules>> GetAllActivePricingAreaRuleAsync();
        Task SaveChangesAsync();
    }
}
