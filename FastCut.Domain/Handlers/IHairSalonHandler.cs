
using FastCut.Domain.Commands.HairSalon;
using FastCut.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Domain.Handlers
{
    public interface IHairSalonHandler //: IHandler<OpenHairSalonCommand>
    {
        IResult OpenHair();
    }
}
