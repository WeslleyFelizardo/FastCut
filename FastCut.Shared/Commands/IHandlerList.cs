using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Shared.Commands
{
    public interface IHandlerList<T> where T : ICommand
    {
        ICommandResult Handler(List<T> command);
    }
}
