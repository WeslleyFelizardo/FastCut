using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public int Id { get; set; }
    }
}
