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
            base.OnModelCreating(modelBuilder);
        }
    }
}
