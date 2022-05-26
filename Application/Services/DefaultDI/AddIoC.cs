using Alkemy.Disney.Api.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Services.DefaultDI
{
    public static class AddIoC
    {
        public static IServiceCollection AddNotificationServices(this IServiceCollection services)
        {
            // services.AddDbContext<NotificationDbContext>(cfg => cfg.UseSqlServer(configuration.GetConnectionString("NotificationConnection")));
            services.AddTransient<IProductionService, ProductionService>();
            services.AddTransient<IProductionRepository, ProductionRepository>();
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<IPersonageService, PersonajeService>();
            services.AddTransient<IPersonageRepository, PersonageRepository>();

            return services;
        }

    }
}
