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
        public string Name { get; private set; }
        public DateTime? Brithdate { get; private set; }
        public Address Address { get; private set; }
        public string Phone { get; private set; }
        public Email Email { get; private set; }

        protected Employee()
        {
        }

        public Employee(string name, DateTime? brithdate, string phone, Address address, Email email)
        {
            Name = name;
            Brithdate = brithdate;
            Address = address;
            Phone = phone;
            Email = email;
        }
    }
}
