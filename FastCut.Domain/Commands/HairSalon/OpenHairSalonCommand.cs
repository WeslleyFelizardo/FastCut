using FastCut.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Commands.HairSalon
{
    public class OpenHairSalonCommand : ICommand
    {
        public string TenantId { get; set; }
    }
}
