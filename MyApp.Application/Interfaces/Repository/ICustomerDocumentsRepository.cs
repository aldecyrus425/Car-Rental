using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface ICustomerDocumentsRepository
    {
        Task<IEnumerable<CustomerDocuments>> GetAllCustomerDocumentsAsync(Guid customerId);
        Task<CustomerDocuments?> GetCustomerDocumentIdAsync(Guid documentId);
        Task CreateDocumentAsync(CustomerDocuments document);
        Task SaveChangesAsync();
    } 
}
