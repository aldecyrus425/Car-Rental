using MyApp.Application.Features.RentalAgreement.Create;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IRentalDocumentRepository
    {
        Task CreateRentalDocumentAsync(RentalDocuments rentalDocument);
        Task SaveChangesAsync();
    }
}
