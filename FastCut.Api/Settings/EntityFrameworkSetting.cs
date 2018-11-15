
using FastCut.Infra.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCut.Api.Settings
{
    public static class EntityFrameworkSetting
    {
        public static void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddEntityFrameworkSqlServer()
             .AddDbContext<FastCutContext>();
            //services.AddScoped<>();
        }
    }
}
