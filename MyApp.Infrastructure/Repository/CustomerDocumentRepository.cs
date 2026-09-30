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
    public class CustomerDocumentRepository : ICustomerDocumentsRepository
    {
        private readonly ApplicationDBContext _context;

        public CustomerDocumentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateDocumentAsync(CustomerDocuments document)
        {
            await _context.CustomerDocuments.AddAsync(document);
        }

        public async Task<IEnumerable<CustomerDocuments>> GetAllCustomerDocumentsAsync(Guid customerId)
        {
            return await _context.CustomerDocuments.Where(d => d.CustomerId == customerId).ToListAsync();
        }

        public async Task<CustomerDocuments?> GetCustomerDocumentIdAsync(Guid documentId)
        {
            return await _context.CustomerDocuments.FirstOrDefaultAsync(d => d.CustomerDocumentId == documentId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
