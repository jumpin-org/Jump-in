using JumpIn.Admin.BusinessLogicLayer.CommandHandlers;
using JumpIn.Admin.BusinessLogicLayer.Commands;
using JumpIn.Admin.BusinessLogicLayer.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace JumpIn.Admin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : Controller
    {
        [HttpPost("Account", Name = nameof(CreateAccount))]
        public Task<int> CreateAccount(
            [FromServices] CreateAccountCommandHandler handler,
            [FromBody] CreateAccountCommand createAccountCommand)
        {
            return handler.Handle(createAccountCommand);
        }

    }
}
