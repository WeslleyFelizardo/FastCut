using FastCut.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Entities
{
    public class Booking : Entity
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
    }
}
