
using FastCut.Infra.Datas;
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

            //services.AddScoped(typeof(IRepositorioSincrono<>), typeof(RepositorioBase<>));
            //services.AddScoped(typeof(IRepositorioAssincrono<>), typeof(RepositorioBase<>));
            //services.AddScoped(typeof(IRepositorioColaborador), typeof(RepositorioColaborador));
            //services.AddScoped<IDeviceViewModelValidationRules, DeviceViewModelValidationRules>();

            //services.AddTransient<IDeviceService, DeviceService>();
            //services.AddTransient<IDeviceValidationService, DeviceValidationService>();

            services.AddTransient<IDatabaseManager, DatabaseManager>();
            services.AddTransient<IContextFactory, ContextFactory>();

            //services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
