using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.FileStorage
{
    public interface IFileStorageServices
    {
        Task<string> SaveAsync(Stream fileStream, string fileName, string folder, CancellationToken token);
    }
}
