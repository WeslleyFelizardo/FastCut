using FastCut.Domain.Commands.Employee;
using FastCut.Domain.Commands.ServiceEmployee;
using FastCut.Domain.Entities;
using FastCut.Domain.EventBus;
using FastCut.Domain.EventBus.Events;
using FastCut.Domain.ValueObjects;
using FastCut.Domain.ViewModels;
using FastCut.Shared.Commands;
using FastCut.Shared.Repository;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastCut.Domain.Handlers
{
    public class EmployeeHandler : Notifiable, IEmployeeHandler

    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Service> _serviceRepository;
        private readonly IRepository<ServiceEmployee> _serviceEmployeeRepository;
        private readonly IEventBus _eventBus;
        public EmployeeHandler(
            IRepository<Employee> employeeRepository, 
            IRepository<Service> serviceRepository, 
            IRepository<ServiceEmployee> serviceEmployeeRepository,
            IEventBus eventBus
            )
        {
            _employeeRepository = employeeRepository;
            _serviceRepository = serviceRepository;
            _serviceEmployeeRepository = serviceEmployeeRepository;
            _eventBus = eventBus;
        }

        public ICommandResult Handler(CreateEmployeeCommand command)
        {
            var employee = new Employee(command.Name, command.Brithdate, command.Phone, new Address(command.City, command.Neighborhood, command.ZipCode, command.Country, command.Street, command.State), new Email(command.Address));

            AddNotifications(employee);

            if (employee.Invalid)
                return new CommandResult(false, "Dados inválidos", null, Notifications);

            var employeeCreated = _employeeRepository.Save(employee);

            // Emitir para a fila a criação do employee e registrar o usuário na no identity provider
            _eventBus.Publish(new CreatedEmployeeEvent(employee.Email.Address, command.Password, employeeCreated.Id));

            return new CommandResult(true, "Funcionário criado com sucesso", new EmployeeCreatedViewModel(employeeCreated.Id, employeeCreated.Name), Notifications);
        }

        public ICommandResult Handler(UpdateEmployeeCommand command)
        {
            var employee = new Employee(command.Name, command.Brithdate, command.Phone, new Address(command.City, command.Neighborhood, command.ZipCode, command.Country, command.Street, command.State), new Email(command.Address));

            AddNotifications(employee);

            if (employee.Invalid)
                return new CommandResult(false, "Dados inválidos", null, Notifications);

            var employeeCreated = _employeeRepository.Save(employee);

            return new CommandResult(true, "Funcionário atualizado com sucesso", new EmployeeUpdatedViewModel(employeeCreated.Id, employeeCreated.Name), Notifications);
        }

        public ICommandResult Handler(DeleteEmployeeCommand command)
        {
            var employee = _employeeRepository.GetById(command.Id);

            if (employee == null)
                return new CommandResult(false, $"Funcionário com o id {command.Id} não existe", null, Notifications);

            _employeeRepository.Delete(employee);

            return new CommandResult(true, "Funcionário excluído com sucesso", null, Notifications);
        }

        public ICommandResult Handler(CreateAssociationCommand command)
        {
            command.Validate();

            AddNotifications(command);

            if (command.Invalid)
                return new CommandResult(false, "Dados inválidos", null, Notifications);

            var employee = _employeeRepository.GetById(command.IdEmployee);

            if (employee == null)
                return new CommandResult(false, "Esse funcionário não existe no sistema", null, Notifications);

            var services = _serviceRepository.GetByIds(command.IdsService);

            if (services.Count() != command.IdsService.Count())
                return new CommandResult(false, "Foram informados serviços que não existe", null, Notifications);

            foreach (var item in services)
            {
                _serviceEmployeeRepository.Save(new ServiceEmployee(item.Id, employee.Id));
            }

            return new CommandResult(true, $"Os serviços selecionados foram associados ao funcionário {employee.Name}", null, Notifications);
        }
    }
}
