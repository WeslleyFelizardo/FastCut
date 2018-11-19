using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.EventBus
{
    public abstract class IntegrationEvent
    {
        protected IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime CreateAt { get; private set; }


    }
}
