using FastCut.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Entities
{
    public class ServiceEmployee : Entity
    {
        public int IdService { get; set; }
        public int IdEmployee { get; set; }
        public Service Service { get; set; }
        public Employee Employee { get; set; }
    }
}
