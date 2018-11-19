
using FastCut.Domain.EventBus;
using FastCut.Domain.Handlers;
using FastCut.Domain.Repositories;
using FastCut.Infra.Datas;
using FastCut.Infra.EventBus;
using FastCut.Infra.Repositories;
using FastCut.Shared.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCut.Api.Settings
{
    public static class IocSetting
    {
        public static void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Repositories

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IServiceRepository), typeof(ServiceRepository));

            // Handlers

            services.AddScoped(typeof(IEmployeeHandler), typeof(EmployeeHandler));
            services.AddScoped(typeof(IServiceHandler), typeof(ServiceHandler));

            services.AddScoped(typeof(IEventBus), typeof(EventBus));

            services.AddTransient<IDatabaseManager, DatabaseManager>();
            services.AddTransient<IContextFactory, ContextFactory>();
            

        }
    }
}
