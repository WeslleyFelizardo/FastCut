
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FastCut.Bus
{
    public class EventBus : IEventBus
    {
        private readonly IBusControl _bus;
        public EventBus(IBusControl busControl)
        {
            _bus = busControl;
            
        }

        public async Task Publish<T>(T @event) where T : IntegrationEvent
        {
            await _bus.Publish<T>(@event);
        }

        public async Task Send<T>(T command, string queue) where T : CommandEvent
        {
            var sendToUri = new Uri($"{"rabbitmq://localhost/"}{queue}");
            var endPoint = await _bus.GetSendEndpoint(sendToUri);

            await endPoint.Send<T>(command);
        }
    }
}
