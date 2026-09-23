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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CustomerRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCustomerAsync(Customers customer)
        {
            await _dbContext.Customers.AddAsync(customer);
        }

        public async Task<IEnumerable<Customers>> GetAllActivateCustomerAsync()
        {
            return await _dbContext.Customers.Where(x => x.Status == "Active").ToListAsync();
        }

        public async Task<IEnumerable<Customers>> GetAllCustomerAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customers?> GetCustomerByIdAsync(Guid id)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
