using FastCut.Shared.ValueObjects;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;
        }
    }
}
