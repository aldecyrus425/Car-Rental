using Microsoft.AspNetCore.Hosting;
using MyApp.Application.Interfaces.FileStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Services
{
    public class FileStorageServices : IFileStorageServices
    {
        private readonly IWebHostEnvironment _environtment;
        public FileStorageServices(IWebHostEnvironment environtment)
        {
            _environtment = environtment;
        }

        public async Task DeleteAsync(string filePath, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return;

            var fullPath = Path.Combine(_environtment.WebRootPath, filePath);
            if(File.Exists(fullPath))
            {
                await Task.Run(() => File.Delete(fullPath), token);
            }

        }

        public async Task<string> SaveAsync(Stream fileStream, string fileName, string folder, CancellationToken token)
        {
            var uploadsFolder = Path.Combine(_environtment.WebRootPath, folder);

            Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);

            await fileStream.CopyToAsync(stream, token);

            return $"/{folder.Trim('/')}/{fileName}";
        }
    }
}
