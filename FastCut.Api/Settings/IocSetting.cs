

using FastCut.Bus;
using FastCut.Domain.Handlers;
using FastCut.Domain.Repositories;
using FastCut.Infra.Datas;

using FastCut.Infra.Repositories;
using FastCut.Shared.Repository;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddScoped(typeof(IHairSalonHandler), typeof(HairSalonHandler));

            services.AddScoped(typeof(IEventBus), typeof(EventBus));

            services.AddTransient<IDatabaseManager, DatabaseManager>();
            services.AddTransient<IContextFactory, ContextFactory>();

            services.AddSingleton(provider => MassTransit.Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost"), h => {
                    h.Username("guest");
                    h.Password("guest");
                });

                //cfg.ReceiveEndpoint(host, "customer_update_queue", e =>
                //{
                //});

            }));


            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IHostedService, BusHostedService>();

        }
    }
}
