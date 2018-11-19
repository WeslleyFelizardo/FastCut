using FastCut.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastCut.Domain.Entities
{
    public class ServiceEmployee : Entity
    {
        private readonly IList<RequestService> _requestServices;

        public ServiceEmployee(int serviceId, int employeeId)
        {
            ServiceId = serviceId;
            EmployeeId = employeeId;

            _requestServices = new List<RequestService>();
        }

        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public Service Service { get; set; }
        public Employee Employee { get; set; }
        public ICollection<RequestService> RequestServices => _requestServices.ToArray();
    }
}
