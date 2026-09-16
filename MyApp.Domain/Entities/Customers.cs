using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Customers
    {
        public Guid CustomerId { get; private set; }
        public string CustomersNumber { get; private set; }
        public string FirstName { get; private set; }
        public string? MiddleName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string? PostalCode { get; private set; }
        public string? EmergencyContactName { get; private set; }
        public string? EmergencyNumber { get; private set; }
        public string Status { get; private set; } // Active, Blocked, Inactive
        
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        protected Customers() { } // For EF Core

    }
}
