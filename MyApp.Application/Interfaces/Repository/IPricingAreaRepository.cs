using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IPricingAreaRepository
    {
        Task CreatePricingAreaAsync(PricingAreas pricingArea);
        Task<PricingAreas?> GetPricingAreaByIdAsync(Guid pricingAreaId);
        Task<IEnumerable<PricingAreas>> GetAllPricingAreaAsync();
        Task<IEnumerable<PricingAreas>> GetAllActivePricingAreaAsync();
        Task SaveChangesAsync();
    }
}
