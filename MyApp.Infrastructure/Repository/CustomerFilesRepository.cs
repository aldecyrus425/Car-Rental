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
    public class CustomerFilesRepository : ICustomerFilesRepository
    {
        private readonly ApplicationDBContext _context;
        public CustomerFilesRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateFiles(CustomerDocumentFiles files)
        {
            await _context.CustomerDocumentFiles.AddAsync(files);
        }

        public async Task<IEnumerable<CustomerDocumentFiles>> GetAllFilesByDocumentIdAsync(Guid documentId)
        {
            return await _context.CustomerDocumentFiles.Where(x => x.CustomerDocumentId == documentId).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
