using FastCut.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Commands.Service
{
    public class DeleteServiceCommand : ICommand
    {
        public DeleteServiceCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
