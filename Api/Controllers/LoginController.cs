using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core;
using Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly JwtManager manager;

        public LoginController(JwtManager manager)
        {
            this.manager = manager;
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Post([FromBody] LoginUserDto request)
        {
            var token = manager.MakeToken(request.Email, request.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }

    }
}
