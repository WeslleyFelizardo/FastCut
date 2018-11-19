using FastCut.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string city, string neighborhood, string zipCode, string country, string street, string state)
        {
            City = city;
            Neighborhood = neighborhood;
            ZipCode = zipCode;
            Country = country;
            Street = street;
            State = state;
        }

        public string City { get; private set; }
        public string Neighborhood { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public string Street { get; private set; }
        public string State { get; private set; }
    }
}
