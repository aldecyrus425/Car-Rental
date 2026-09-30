using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class CustomerDocuments
    {
        public Guid CustomerDocumentId { get; private set; }

        public Guid CustomerId { get; private set; }
        public Customers Customer { get; private set; }

        public string DocumentType { get; private set; }

        public string? DocumentNumber { get; private set; }

        public DateOnly? ExpirationDate { get; private set; }

        public bool IsVerified { get; private set; }

        public Guid? VerifiedByUserId { get; private set; }
        public Users? VerifiedByUser { get; private set; }

        public DateTime? VerifiedAt { get; private set; }

        public string? Remarks { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public ICollection<CustomerDocumentFiles> Files { get; private set; } = new List<CustomerDocumentFiles>();

        protected CustomerDocuments() { }

        //        CustomerDocumentId | CustomerId | DocumentType     | DocumentNumber
        //        -------------------|------------|------------------|----------------
        //        DOC-001            | CUST-001   | DriverLicense    | N01-23-456789
        //        DOC-002            | CUST-001   | NationalID       | 1234-5678-9012
        //        DOC-003            | CUST-001   | ProofOfAddress   | NULL

        public CustomerDocuments(Guid customerId, string documentType, string? documentNumber, DateOnly? expirationDate, bool isVerified, Guid? verifiedByUserId, string? remarks)
        {
            CustomerId = customerId;
            DocumentType = documentType;
            DocumentNumber = documentNumber;
            ExpirationDate = expirationDate;
            IsVerified = isVerified;
            if (isVerified)
            {
                VerifiedByUserId = verifiedByUserId;
                VerifiedAt = DateTime.Now;
            }
            Remarks = remarks;
            CreatedAt = DateTime.Now;
        }
    }
}
