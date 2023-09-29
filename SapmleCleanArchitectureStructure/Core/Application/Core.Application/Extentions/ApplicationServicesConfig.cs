using Core.Application.Services.Book;
using Core.Domain.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Extentions
{
    public static class ApplicationServicesConfig
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // add services
            services.AddScoped<IBooksService, BooksService>();
        }
    }
}
