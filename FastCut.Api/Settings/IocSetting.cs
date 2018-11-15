
using FastCut.Domain.Repositories;
using FastCut.Infra.Datas;
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

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IServiceRepository), typeof(ServiceRepository));

            services.AddTransient<IDatabaseManager, DatabaseManager>();
            services.AddTransient<IContextFactory, ContextFactory>();
            
            //services.AddScoped<IDbContext>(provider => provider.GetService<FastCutContext>());

            //services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
