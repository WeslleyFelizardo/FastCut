using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Entities
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; } 

    }
}
