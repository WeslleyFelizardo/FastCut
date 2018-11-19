using FastCut.Domain.Commands.Service;
using FastCut.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Handlers
{
    public interface IServiceHandler : 
        IHandler<CreateServiceCommand>,
        IHandler<UpdateServiceCommand>,
        IHandler<DeleteServiceCommand>
    {
    }
}
