using FastCut.Domain.EventBus;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Infra.EventBus
{
    public class EventBus : IEventBus, IDisposable
    {
        private readonly IBusControl _bus;
        public EventBus()
        {
            _bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");

                });
            });
        }

        public void Dispose()
        {
            _bus.Stop();
        }

        public void Publish<T>(T @event) where T : IntegrationEvent
        {
            _bus.Start();
            _bus.Publish<T>(@event);
        }
    }
}
