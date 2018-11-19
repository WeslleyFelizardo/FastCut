using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.EventBus.Events
{
    public class CreatedEmployeeEvent : IntegrationEvent
    {
        public CreatedEmployeeEvent(string email, string password, int idEmployee) : base()
        {
            Email = email;
            Password = password;
            IdEmployee = idEmployee;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public int IdEmployee { get; private set; }
    }
}
