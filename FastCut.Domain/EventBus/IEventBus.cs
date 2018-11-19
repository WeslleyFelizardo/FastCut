using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.EventBus
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : IntegrationEvent;


    }
}
