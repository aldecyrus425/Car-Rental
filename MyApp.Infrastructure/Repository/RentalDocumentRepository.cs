using MyApp.Application.Features.RentalAgreement.Create;
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
    public class RentalDocumentRepository : IRentalDocumentRepository
    {
        private readonly ApplicationDBContext _context;

        public RentalDocumentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateRentalDocumentAsync(RentalDocuments rentalDocument)
        {
            await _context.RentalDocuments.AddAsync(rentalDocument);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
