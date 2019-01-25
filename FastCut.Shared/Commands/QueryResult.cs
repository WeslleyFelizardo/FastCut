using FastCut.Shared.ViewModels;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Shared.Commands
{
    public class QueryResult : IResult
    {
        public QueryResult(string message, IList<IViewModel> datas, IReadOnlyCollection<Notification> notifications)
        {
            Message = message;
            Datas = datas;
            Notifications = notifications;
        }

        public string Message { get; private set; }
        public IList<IViewModel> Datas { get; private set; }
        public IReadOnlyCollection<Notification> Notifications { get; private set; }
        
    }
}
