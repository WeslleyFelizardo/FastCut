using FastCut.Domain.Entities;
using FastCut.Shared.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCut.Api.Controllers
{
    [Route("employees")]
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeController(IRepository<Employee> repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult NewEmployee([FromBody] Employee employee)
        {
            return Created("", _repository.Save(employee));
        }
    }
}
