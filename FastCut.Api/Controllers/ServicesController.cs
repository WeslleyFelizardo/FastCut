using FastCut.Domain.Commands.Service;
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
    [Route("services")]
    public class ServicesController : BaseController
    {
        private readonly IServiceHandler _handler;
        private readonly IRepository<Service> _repository;
        public ServicesController(IServiceHandler handler, IRepository<Service> repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult New([FromBody] CreateServiceCommand service)
        {
            return Ok(_handler.Handler(service));
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

        [HttpPut]
        public IActionResult Update([FromBody] UpdateServiceCommand service)
        {
            return Ok(_handler.Handler(service));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_handler.Handler(new DeleteServiceCommand(id)));
        }


    }
}
