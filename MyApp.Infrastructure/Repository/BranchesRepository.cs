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
    public class BranchesRepository : IBranchRepository
    {
        private readonly ApplicationDBContext _context;
        public BranchesRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateBranchAsync(Branches branches)
        {
            await _context.Branches.AddAsync(branches);
        }

        public async Task<IEnumerable<Branches>> GetAllActiveBranchesAsync()
        {
            return await _context.Branches.Where(b => b.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Branches>> GetAllBranchesAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<Branches?> GetBranchByIdAsync(Guid branchId)
        {
            return await _context.Branches.FirstOrDefaultAsync(b => b.BranchId == branchId);
        }
    }
}
