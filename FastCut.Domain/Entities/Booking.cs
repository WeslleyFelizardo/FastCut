using FastCut.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastCut.Domain.Entities
{
    public class Booking : Entity
    {
        private readonly IList<RequestService> _requestServices;

        public int IdUser { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public ICollection<RequestService> RequestServices => _requestServices.ToArray();

        public Booking()
        {
            _requestServices = new List<RequestService>();
        }
    }
}
