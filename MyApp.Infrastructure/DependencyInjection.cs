using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces.Repository;
using MyApp.Infrastructure.Persistence;
using MyApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ApplicationDBContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBranchRepository, BranchesRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            return services;
        }
    }
}
