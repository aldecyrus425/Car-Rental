using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyApp.Domain.Entities
{
    public class CustomerDocumentFiles
    {
        public Guid CustomerDocumentFileId { get; private set; }

        public Guid CustomerDocumentId { get; private set; }
        public CustomerDocuments CustomerDocument { get; private set; }

        public string FilePath { get; private set; }

        public string FileName { get; private set; }

        public string MimeType { get; private set; }

        public long FileSize { get; private set; }

        public string? FileType { get; private set; }

        public int DisplayOrder { get; private set; }

        public DateTime CreatedAt { get; private set; }

        protected CustomerDocumentFiles() { }


        //        FileId | DocumentId | FileType | FilePath
        //        -------|------------|----------|------------------------------------------
        //        FILE-1 | DOC-001    | Front    | /uploads/customers/CUST-001/dl-front.jpg
        //        FILE-2 | DOC-001    | Back     | /uploads/customers/CUST-001/dl-back.jpg

        //        FILE-3 | DOC-002    | Front    | /uploads/customers/CUST-001/id-front.jpg

        //        FILE-4 | DOC-003    | Page     | /uploads/customers/CUST-001/address-1.jpg
        //        FILE-5 | DOC-003    | Page     | /uploads/customers/CUST-001/address-2.jpg
    }
}
