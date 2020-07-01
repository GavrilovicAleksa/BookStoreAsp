using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly UseCaseExecutor _executor;

        public RegisterController(UseCaseExecutor executor) => _executor = executor;

        [HttpPost]
        public void Post(
            [FromBody] RegisterUserDto dto,
            [FromServices] IRegisterUserCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            
        }

    }
}
