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


            base.OnModelCreating(modelBuilder);
        }
    }
}
