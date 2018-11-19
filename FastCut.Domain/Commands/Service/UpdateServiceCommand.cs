using FastCut.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Commands.Service
{
    public class UpdateServiceCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
