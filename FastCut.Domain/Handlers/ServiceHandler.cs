using System;
using System.Collections.Generic;
using System.Text;
using FastCut.Domain.Commands.Service;
using FastCut.Domain.Entities;
using FastCut.Domain.ViewModels;
using FastCut.Shared.Commands;
using FastCut.Shared.Repository;
using Flunt.Notifications;

namespace FastCut.Domain.Handlers
{
    public class ServiceHandler : Notifiable, IServiceHandler
    {
        private readonly IRepository<Service> _repository;
        public ServiceHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public ICommandResult Handler(CreateServiceCommand command)
        {
            var service = new Service(command.Name, command.Description, command.Price);

            AddNotifications(service);

            if (service.Invalid)
                return new CommandResult(false, "Dados inválidos", null, Notifications);

            var serviceCreated = _repository.Save(service);

            return new CommandResult(true, "Dados salvo com sucesso", new ServiceCreatedViewModel(serviceCreated.Id, service.Name), Notifications);
        }

        public ICommandResult Handler(UpdateServiceCommand command)
        {
            var service = new Service(command.Name, command.Description, command.Price);

            AddNotifications(service);

            if (service.Invalid)
                return new CommandResult(false, "Dados inválidos", null, Notifications);

            var serviceCreated = _repository.Update(service);

            return new CommandResult(true, "Dados salvo com sucesso", new ServiceUpdatedViewModel(serviceCreated.Id, service.Name), Notifications);

        }

        public ICommandResult Handler(DeleteServiceCommand command)
        {
            var service = _repository.GetById(command.Id);

            if (service == null)
                return new CommandResult(false, $"Serviço com o id {command.Id} não existe", null, Notifications);

            _repository.Delete(service);

            return new CommandResult(true, "Serviço excluído com sucesso", null, Notifications);
        }
    }
}
