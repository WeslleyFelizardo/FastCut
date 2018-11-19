using FastCut.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastCut.Domain.Entities
{
    public class Service : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
        public bool Available { get; private set; }

        protected Service()
        {
            
        }

        public Service(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
            Active = true;
            Available = true;
        }
    }
}
