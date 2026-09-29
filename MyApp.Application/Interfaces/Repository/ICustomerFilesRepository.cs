using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface ICustomerFilesRepository
    {
        Task CreateFiles(CustomerDocumentFiles files);
        Task<IEnumerable<CustomerDocumentFiles>> GetAllFilesByDocumentIdAsync(Guid documentId);
        Task SaveChangesAsync();
    }
}
