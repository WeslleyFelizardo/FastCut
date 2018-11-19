using FastCut.Domain.Commands.ServiceEmployee;
using FastCut.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCut.Api.Controllers
{
    [Route("association-service-employee")]
    public class AssociationServiceWithEmployeeController : BaseController
    {
        private readonly IEmployeeHandler _employeeHadler;
        public AssociationServiceWithEmployeeController(IEmployeeHandler employeeHandler)
        {
            _employeeHadler = employeeHandler;
        }

        [HttpPost]
        public IActionResult New([FromBody] CreateAssociationCommand association)
        {
            return Ok(_employeeHadler.Handler(association));
        }

    }
}
