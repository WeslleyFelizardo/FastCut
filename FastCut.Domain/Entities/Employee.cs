using FastCut.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FastCut.Domain.Entities
{
    public class Employee : Entity
    {
        private readonly IList<Service> _services;

        public string Name { get; set; }
        public DateTime? BrithDay { get; set; }
        public string Address { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Service> Services => _services.ToArray();
        public Employee()
        {
            _services = new List<Service>();
        }
    }
}
