using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(x => x.UserId);

            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(x => x.UserRoleId);

                entity.HasMany(x => x.Users)
                      .WithOne(x => x.UserRole)
                      .HasForeignKey(x => x.UserRoleId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(x => x.CustomerId);
            });

            modelBuilder.Entity<CustomerDocuments>(entity =>
            {
                entity.HasKey(x => x.CustomerDocumentId);

                entity.HasOne(x => x.Customer)
                      .WithMany(x => x.Documents)
                      .HasForeignKey(x => x.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CustomerDocumentFiles>(entity =>
            {
                entity.HasKey(x => x.CustomerDocumentFileId);

                entity.HasOne(x => x.CustomerDocument)
                      .WithMany(x => x.Files)
                      .HasForeignKey(x => x.CustomerDocumentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<VehicleTypes>(entity =>
            {
                entity.HasKey(x => x.VehicleTypeId);
            });

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.HasKey(x => x.VehicleId);
                entity.HasOne(x => x.VehicleTypes)
                      .WithMany(x => x.Vehicles)
                      .HasForeignKey(x => x.VehicleTypeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<VehicleImages>(entity =>
            {
                entity.HasKey(x => x.VehicleImageId);
                entity.HasOne(x => x.Vehicle)
                      .WithMany(x => x.VehicleImages)
                      .HasForeignKey(x => x.VehicleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Branches>(entity =>
            {
                entity.HasKey(x => x.BranchId);

                entity.HasMany(x => x.Vehicles)
                      .WithOne(x => x.Branch)
                      .HasForeignKey(x => x.BranchId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RentalAgreements>(entity =>
            {
                entity.HasKey(x => x.RentalAgreementId);

                entity.HasOne(x => x.Customer)
                .WithMany(x => x.RentalAgreements)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Users)
                .WithMany(x => x.RentalAgreements)
                .HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
                

            });

            modelBuilder.Entity<RentalVehicles>(entity =>
            {
                entity.HasKey(x => x.RentalVehicleId);

                entity.HasOne(x => x.Agreements)
                .WithMany(x => x.RentalVehicle)
                .HasForeignKey(x => x.RentalId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Vehicles)
                .WithMany(x => x.RentalVehicle)
                .HasForeignKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<RentalDestinations>(entity =>
            {
                entity.HasKey(x => x.RentalDestinationId);

                entity.HasOne(x => x.RentalAgreement)
                .WithMany(x => x.RentalDestinations)
                .HasForeignKey(x => x.RentalId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.PricingAreas)
                .WithMany(x => x.RentalDestinations)
                .HasForeignKey(x => x.AreaId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PricingAreas>(entity =>
            {
                entity.HasKey(x => x.PricingAreaId);
            });

            modelBuilder.Entity<PricingAreaRules>(entity =>
            {
                entity.HasKey(x => x.PricingAreaRuleId);

                entity.HasOne(x => x.PricingAreas)
                .WithMany(x => x.PricingAreaRules)
                .HasForeignKey(x => x.PricingAreaId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.VehicleTypes)
                .WithMany(x => x.PricingAreaRules)
                .HasForeignKey(x => x.VehicleTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PricingRules>(entity =>
            {
                entity.HasKey(x => x.PricingRulesId);

                entity.HasOne(x => x.VehicleTypes)
                .WithMany(x => x.PricingRules)
                .HasForeignKey(x => x.VehicleTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RentalCharges>(entity =>
            {
                entity.HasKey(x => x.RentalChargeId);

                entity.HasOne(x => x.Agreements)
                .WithMany(x => x.RentalCharges)
                .HasForeignKey(x => x.RentalChargeId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RentalDocuments>(entity =>
            {
                entity.HasKey(x => x.RentalDocumentId);

                entity.HasOne(x => x.Agreement)
                .WithMany(x => x.RentalDocuments)
                .HasForeignKey(x => x.RentalDocumentId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Users)
                .WithMany(x => x.RentalDocuments)
                .HasForeignKey(x => x.UploadedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(x => x.PaymentsId);

                entity.HasOne(x => x.Users)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.PaymentsId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Agreements)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.RentalId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RentalExtensions>(entity =>
            {
                entity.HasKey(x => x.RentalExtensionId);

                entity.HasOne(x => x.Agreements)
                .WithMany(x => x.RentalExtensions)
                .HasForeignKey(x => x.RentalId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Users)
                .WithMany(x => x.RentalExtensions)
                .HasForeignKey(x => x.ApprovedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<VehicleInspections>(entity =>
            {
                entity.HasKey(x => x.InspectionId);

                entity.HasOne(x => x.Agreements)
                .WithMany(x => x.VehicleInspections)
                .HasForeignKey(x => x.RentalId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Users)
                .WithMany(x => x.VehicleInspections)
                .HasForeignKey(x => x.InspectedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DamageReports>(entity =>
            {
                entity.HasKey(x => x.DamageReportId);

                entity.HasOne(x => x.Agreement)
                .WithMany(x => x.DamageReport)
                .HasForeignKey(x => x.RentalId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Vehicles)
                .WithMany(x => x.DamageReport)
                .HasForeignKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Users)
                .WithMany(x => x.DamageReport)
                .HasForeignKey(x => x.ReportedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AdditionalCharges>(entity =>
            {
                entity.HasKey(x => x.AdditionalChargeId);

                entity.HasOne(x => x.Agreement)
                .WithMany(x => x.AdditionalCharge)
                .HasForeignKey(x => x.RentalId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Users)
                .WithMany(x => x.AdditionalCharge)
                .HasForeignKey(x => x.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
