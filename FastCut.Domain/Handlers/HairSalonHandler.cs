using System;
using System.Collections.Generic;
using System.Text;
using FastCut.Bus;
using FastCut.Bus.Commands;
using FastCut.Domain.Commands.HairSalon;
using FastCut.Domain.Entities;
using FastCut.Domain.ViewModels;
using FastCut.Shared.Commands;
using FastCut.Shared.Repository;
using FastCut.Shared.ViewModels;
using Flunt.Notifications;

namespace FastCut.Domain.Handlers
{
    public class HairSalonHandler : Notifiable, IHairSalonHandler
    {
        private readonly IRepository<Employee> _repository;
        private readonly IEventBus _eventBus;
        public HairSalonHandler(IRepository<Employee> repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public IResult OpenHair()
        {
            IList<OpenHairSalonCommandEvent> employeesCommandEvents = new List<OpenHairSalonCommandEvent>();
            IList<IViewModel> employeesAviable = new List<IViewModel>();

            var employees = _repository.GetAll();

            foreach (var item in employees)
            {
                employeesCommandEvents.Add(new OpenHairSalonCommandEvent(item.Id, item.Name, ""));
                employeesAviable.Add(new EmployeeAvaibleViewModel(item.Id, item.Name, ""));
            }

            //_eventBus.Send(employeesCommandEvents, "open_hair_queue");

            return new QueryResult("Salão aberto com sucesso, os seguintes funcionários", employeesAviable, Notifications);
        }
    }
}
