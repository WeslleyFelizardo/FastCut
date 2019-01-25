using FastCut.Shared.ViewModels;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Shared.Commands
{
    public class CommandResult : IResult
    {
        public CommandResult(bool success, string message, IViewModel data, IReadOnlyCollection<Notification> notifications)
        {
            Success = success;
            Message = message;
            Data = data;
            Notifications = notifications;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public IViewModel Data { get; private set; }
        public IReadOnlyCollection<Notification> Notifications { get; set; }
    }
}
