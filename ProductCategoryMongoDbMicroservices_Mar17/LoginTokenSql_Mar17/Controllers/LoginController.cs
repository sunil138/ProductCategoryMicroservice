using LoginTokenSql_Mar17.Commands;
using LoginTokenSql_Mar17.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginTokenSql_Mar17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
       
        public async Task<ActionResult> Create([FromBody] UserDTO userDTO)
        {
            await _mediator.Send(new LoginUserCommand(userDTO));
            return Ok(userDTO); 
        }

      
    }
}
