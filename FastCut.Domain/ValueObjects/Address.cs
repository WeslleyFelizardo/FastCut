using FastCut.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string City { get; private set; }
        public string Neighborhood { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public string Street { get; private set; }
        public string State { get; set; }
    }
}
