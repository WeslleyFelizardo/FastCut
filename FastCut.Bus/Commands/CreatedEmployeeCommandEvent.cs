using FastCut.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Commands
{
    public sealed class CreatedEmployeeCommandEvent : CommandEvent
    {
        public CreatedEmployeeCommandEvent(string email, string password, int idEmployee, string name) : base()
        {
            Email = email;
            Password = password;
            IdEmployee = idEmployee;
            Name = name;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public int IdEmployee { get; set; }
        public string Name { get; set; }
    }
}
