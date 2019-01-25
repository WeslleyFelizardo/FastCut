using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Shared.Commands
{
    public interface IHandler<T> where T : ICommand
    {
        IResult Handler(T command);
        
    }

    
}
