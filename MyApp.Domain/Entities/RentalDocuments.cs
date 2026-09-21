using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class RentalDocuments
    {
        public Guid RentalDocumentId { get; private set; }
        public Guid RentalId { get; private set; }
        public RentalAgreements Agreement { get; private set; }
        public string DocumentType { get; private set; }
        public string FilePath { get; private set; }
        public string FileName { get; private set; }
        public string MimeType { get; private set; }
        public Guid UploadedByUserId { get; private set; }
        public Users Users { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected RentalDocuments() { } 
    }
}
