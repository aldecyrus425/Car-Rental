using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(Customers customer);
        Task<IEnumerable<Customers>> GetAllActivateCustomerAsync();
        Task<IEnumerable<Customers>> GetAllCustomerAsync();
        Task<Customers?> GetCustomerByIdAsync(Guid id);
        Task SaveChangesAsync();

    }
}
