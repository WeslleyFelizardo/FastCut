using FastCut.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastCut.Domain.Entities
{
    public class Service : Entity
    {
        private readonly IList<Employee> _employees;

        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public bool Ativo { get; set; }
        public bool Disponivel { get; set; }

        public virtual ICollection<Employee> Employees => _employees.ToArray();

        public Service()
        {
            _employees = new List<Employee>();
        }
    }
}
