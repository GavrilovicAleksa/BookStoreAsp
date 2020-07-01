using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransfer;
using Application.Filters;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public PublisherController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] GetAll search,
            [FromServices] IGetPublishersQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }


        // POST: api/Author
        [HttpPost]
        public IActionResult Post([FromBody] PublisherInsertDto dto,
            [FromServices] IPublisherInsertCommand command)
        {
            try
            {
                executor.ExecuteCommand(command, dto);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
