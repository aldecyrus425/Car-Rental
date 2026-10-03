using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cToken = default);
        Task BeginTransactionAsync(CancellationToken cToken = default);
        Task CommitTransactionAsync(CancellationToken cToken = default);
        Task RollbackTransactionAsync(CancellationToken cToken = default);
    }
}
