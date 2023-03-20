using LoginTokenSql_Mar17.Commands;
using LoginTokenSql_Mar17.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginTokenSql_Mar17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RegisterController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] Tlogin user)
        {
            await _mediator.Send(new RegisterUserCommand(user));
            return Ok(user); 
        }
    }
}
