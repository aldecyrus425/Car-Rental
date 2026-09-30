using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IBranchRepository
    {
        Task CreateBranchAsync(Branches branches);
        Task<IEnumerable<Branches>> GetAllActiveBranchesAsync();
        Task<IEnumerable<Branches>> GetAllBranchesAsync();
        Task<Branches?> GetBranchByIdAsync(Guid branchId);
        Task SaveChangesAsync();
    }
}
