using FastCut.Domain.Commands.Employee;
using FastCut.Domain.Entities;
using FastCut.Domain.Handlers;
using FastCut.Shared.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCut.Api.Controllers
{
    [Route("employees")]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeHandler _handler;
        private readonly IRepository<Employee> _repository;
        public EmployeeController(IEmployeeHandler handler, IRepository<Employee> repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult New([FromBody] CreateEmployeeCommand employee)
        {
            return Created("", _handler.Handler(employee));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateEmployeeCommand employee)
        {
            employee.Id = id;
            return Ok(_handler.Handler(employee));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_handler.Handler(new DeleteEmployeeCommand(id)));
        }
    }
}
