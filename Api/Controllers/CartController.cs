using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransfer;
using Application.Filters;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public CartController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] GetAll search,
            [FromServices] IGetAllCartItemsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }
    

    // POST api/<CartController>
    [HttpPost]
    public void Post([FromBody] CartInsertDto dto,
       [FromServices] ICartInsertCommand command)
    {
        executor.ExecuteCommand(command, dto);
    }

}
}
