using FastCut.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Commands.Employee
{
    public class DeleteEmployeeCommand : ICommand
    {
        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
