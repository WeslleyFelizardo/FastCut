using FastCut.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCut.Api.Controllers
{
    [Route("hair-salon")]
    public class HairSalonController : BaseController
    {
        private readonly IHairSalonHandler _hairSalonHandler;
        public HairSalonController(IHairSalonHandler hairSalonHandler)
        {
            _hairSalonHandler = hairSalonHandler;
        }

        [HttpGet]
        public IActionResult Open()
        {
            return Ok(_hairSalonHandler.OpenHair());
        }
    }
}
