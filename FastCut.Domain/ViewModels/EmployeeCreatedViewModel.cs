using FastCut.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.ViewModels
{
    public class EmployeeCreatedViewModel : IViewModel
    {
        public EmployeeCreatedViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
