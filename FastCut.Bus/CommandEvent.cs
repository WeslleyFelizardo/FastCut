using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Bus
{
    public abstract class CommandEvent
    {
        protected CommandEvent()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; set; }
    }
}
