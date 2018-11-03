
using FastCut.Infra.Datas;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCut.Api.Settings
{
    public static class OptionsSetting
    {
        public static void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<ConnectionString>(configuration.GetSection("ConnectionStrings"));
        }
    }
}
