using JumpIn.Authentication.API.Dtos;
using JumpIn.Authentication.Domain.CommandHandlers;
using JumpIn.Authentication.Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace JumpIn.Authentication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        [HttpPost("Login", Name = nameof(Login))]
        public async Task<IActionResult> Login(
            [FromServices] LoginCommandHandler handler, 
            [FromBody] LoginRequestDto request)
        {
            var loginResult = await handler.Handle(new LoginCommand(request.email, request.email));
            return loginResult is null ? Unauthorized() : Ok(loginResult);
        }
    }
}