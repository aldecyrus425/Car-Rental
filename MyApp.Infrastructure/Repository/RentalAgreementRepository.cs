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
    public class RentalAgreementRepository : IRentalAgreementRepository
    {
        private readonly ApplicationDBContext _context;

        public RentalAgreementRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateAgreementAsync(RentalAgreements agreement)
        {
            await _context.RentalAgreements.AddAsync(agreement);
        }

        public async Task<RentalAgreements?> GetAgreementByIdAsync(Guid agreementId)
        {
            return await _context.RentalAgreements.FirstOrDefaultAsync(x => x.RentalAgreementId == agreementId);
        }

        public async Task<IEnumerable<RentalAgreements>> GetAllAgreementsAsync()
        {
            return await _context.RentalAgreements.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
