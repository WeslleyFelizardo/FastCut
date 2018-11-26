using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FastCut.Bus
{
    public interface IEventBus
    {
        Task Publish<T>(T @event) where T : IntegrationEvent;

        Task Send<T>(T command, string queue) where T : CommandEvent;
    }
}
