using FastCut.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.ViewModels
{
    public class EmployeeAvaibleViewModel : IViewModel
    {
        public EmployeeAvaibleViewModel(int id, string name, string nickName)
        {
            Id = id;
            Name = name;
            NickName = nickName;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string NickName { get; private set; }
    }
}
