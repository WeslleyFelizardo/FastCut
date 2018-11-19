using FastCut.Domain.Commands.Employee;
using FastCut.Domain.Commands.ServiceEmployee;
using FastCut.Domain.Entities;
using FastCut.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Handlers
{
    public interface IEmployeeHandler :
        IHandler<CreateEmployeeCommand>,
        IHandler<UpdateEmployeeCommand>,
        IHandler<DeleteEmployeeCommand>,
        IHandler<CreateAssociationCommand>
    {
    }
}
