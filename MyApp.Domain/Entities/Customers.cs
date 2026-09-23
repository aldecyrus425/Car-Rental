using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        public ICollection<CustomerDocuments> Documents { get; private set; } = new List<CustomerDocuments>();
        public ICollection<RentalAgreements> RentalAgreements { get; private set; } = new List<RentalAgreements>();


        public Customers(string customerNumber, string firstName, string? middleName, string lastName, DateOnly dateOfBirth, string gender, string email, string phoneNumber, string address, string city, string province, string?  postalCode, string? emergencyContactName, string? emergencyNumber, string status)
        {
            CustomersNumber = customerNumber;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            Province = province;
            PostalCode = postalCode;
            EmergencyContactName = emergencyContactName;
            EmergencyNumber = emergencyNumber;
            Status = status;
            CreatedAt = DateTime.Now;
        }

        public void UpdateCustomers(string? firstName, string? middleName, string? lastName, DateOnly? dateOfBirth, string? gender, string? email, string? phoneNumber, string? address, string? city, string? province, string? postalCode, string? emergencyContactName, string? emergencyNumber)
        {
            FirstName = firstName ?? FirstName;
            MiddleName = middleName ?? MiddleName;
            LastName = lastName ?? LastName;
            DateOfBirth = dateOfBirth ?? DateOfBirth;
            Gender = gender ?? Gender;
            Email = email ?? Email;
            PhoneNumber = phoneNumber ?? PhoneNumber;
            Address = address ?? Address;
            City = city ?? City;
            Province = province ?? Province;
            PostalCode = postalCode ?? PostalCode;
            EmergencyContactName = emergencyContactName ?? EmergencyContactName;
            EmergencyNumber = emergencyNumber ?? EmergencyNumber;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateStatus(string status)
        {
            Status = status;
        }

    }
}
