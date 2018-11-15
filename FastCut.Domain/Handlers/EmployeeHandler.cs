using FastCut.Domain.Commands.Employee;
using FastCut.Domain.Entities;
using FastCut.Shared.Commands;
using FastCut.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Handlers
{
    public class EmployeeHandler :
        IHandler<CreateEmployeeCommand>,
        IHandler<UpdateEmployeeCommand>
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeHandler(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ICommandResult Handler(CreateEmployeeCommand command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handler(UpdateEmployeeCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
