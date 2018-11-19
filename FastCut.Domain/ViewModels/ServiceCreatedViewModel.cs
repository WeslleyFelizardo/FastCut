using FastCut.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.ViewModels
{
    public class ServiceCreatedViewModel : IViewModel
    {
        public ServiceCreatedViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
