using FastCut.Domain.ValueObjects;
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

        public string Name { get; private set; }
        public DateTime? BrithDay { get; private set; }
        public Address Address { get; private set; }
        public string Phone { get; private set; }
        public Email Email { get; private set; }

        public virtual ICollection<Service> Services => _services.ToArray();
        protected Employee()
        {
            _services = new List<Service>();
        }

        public Employee(string name, DateTime? brithDay, Address address, string phone, Email email)
        {
            Name = name;
            BrithDay = brithDay;
            Address = address;
            Phone = phone;
            Email = email;
        }
    }
}
