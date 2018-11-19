using FastCut.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Commands.Employee
{
    public class CreateEmployeeCommand : ICommand
    {
        public string Name { get; set; }
        public DateTime? Brithdate { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
