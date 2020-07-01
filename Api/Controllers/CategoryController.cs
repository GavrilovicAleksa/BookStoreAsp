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
    public class CategoryController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public CategoryController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] GetAll search,
            [FromServices] IGetCategoriesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }


        // POST: api/Author
        [HttpPost]
        public IActionResult Post([FromBody] CategoryInsertDto dto,
            [FromServices] ICategoryInsertCommand command)
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
