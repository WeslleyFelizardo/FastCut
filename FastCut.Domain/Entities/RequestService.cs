using FastCut.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Entities
{
    public class RequestService : Entity
    {
        public DateTime Created { get; set; }
        public int IdServiceEmployee { get; set; }
        public ServiceEmployee ServiceEmployee { get; set; }
        public int IdBooking { get; set; }
        public Booking Booking { get; set; }
    }
}
