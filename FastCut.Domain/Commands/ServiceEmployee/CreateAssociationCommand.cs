using FastCut.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastCut.Domain.Commands.ServiceEmployee
{
    public class CreateAssociationCommand : Notifiable, ICommand, IValidatable
    {
        public int[] IdsService { get; set; }
        public int IdEmployee { get; set; }

        public void Validate()
        {
            AddNotifications(
            new Contract()
                .Requires()
                .IsFalse(!IdsService.Any(), "Serviços", "Por favor, informe no minímo um serviço")
            );
        }
    }
}
