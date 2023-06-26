using JumpIn.Authentication.API.Login;
using JumpIn.Authentication.API.Models;
using JumpIn.Authentication.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace JumpIn.Authentication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly LoginCommandHandler loginCommandHandler;

        public AuthorizationController(LoginCommandHandler loginCommandHandler)
        {
            this.loginCommandHandler = loginCommandHandler;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var loginResult = loginCommandHandler.Handle(new LoginCommand(request.email, request.email));
            return loginResult is null ? Unauthorized() : Ok(loginResult);
        }
    }
}