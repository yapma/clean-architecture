using Core.Domain.Contracts.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Extentions
{
    public static class PersistenceServicesConfig
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // config of ef-core
            services.AddDbContext<ApplicationDbContext>(config =>
            {
                config.UseSqlServer(configuration.GetConnectionString("MainConnection"));
            });

            // config identity
            services.AddIdentityCore<User>(config =>
            {
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireLowercase = true;
                config.Password.RequireUppercase = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddRoles<IdentityRole>();
            //.AddDefaultTokenProviders();

            // add services
            services.AddScoped<IBooksRepository, BooksRepository>();
        }
    }
}
