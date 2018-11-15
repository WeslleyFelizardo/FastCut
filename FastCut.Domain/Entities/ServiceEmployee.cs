using FastCut.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Entities
{
    public class ServiceEmployee : Entity
    {
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public Service Service { get; set; }
        public Employee Employee { get; set; }
    }
}
