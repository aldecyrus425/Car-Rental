using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Users
    {
        public Guid UserId { get; private set; }
        public string FirstName { get; private set; }
        public string? MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string PasswordHash { get; private set; }
        public Guid UserRoleId { get; private set; }
        public UserRoles UserRole { get; private set; }
        public bool IsActive { get; private set; }
        
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        protected Users() { } // For EF Core

        public ICollection<RentalAgreements> RentalAgreements { get; private set; } = new List<RentalAgreements>();
        public ICollection<RentalDocuments> RentalDocuments { get; private set; } = new List<RentalDocuments>();
        public ICollection<Payments> Payments { get; private set; } = new List<Payments>();
        public ICollection<RentalExtensions> RentalExtensions = new List<RentalExtensions>();
        public ICollection<VehicleInspections> VehicleInspections = new List<VehicleInspections>();
        public ICollection<DamageReports> DamageReport = new List<DamageReports>();
        public ICollection<AdditionalCharges> AdditionalCharge { get; private set; } = new List<AdditionalCharges>();
        public ICollection<VehicleMaintenance> VehicleMaintenance { get; private set; } = new List<VehicleMaintenance>();


        public Users(string firstname, string? middlename, string lastname, string email, string phonenumber, string hashpassword, Guid userRoleId, bool isActive)
        {
            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
            Email = email;
            PhoneNumber = phonenumber;
            PasswordHash = hashpassword;
            UserRoleId = userRoleId;
            IsActive = isActive;
        }

    }
}
