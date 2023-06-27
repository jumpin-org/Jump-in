using JumpIn.Admin.BusinessLogicLayer.CommandHandlers;
using JumpIn.Admin.BusinessLogicLayer.Commands;
using JumpIn.Admin.BusinessLogicLayer.Dtos;
using JumpIn.Admin.BusinessLogicLayer.QueryHandlers;
using JumpIn.Common.Utility.Helpers;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JumpIn.Admin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        [HttpGet("Users", Name = nameof(GetUsers))]
        public Task<List<string>> GetUsers(
            [FromServices] GetAllUsersHandler handler)
        {
            return handler.Execute();
        }

        [HttpPost("User", Name = nameof(CreateUser))]
        public Task<int> CreateUser(
            [FromServices] CreateUserCommandHandler handler,
            [FromBody] UserDto userDto)
        {
            return handler.Handle(new CreateUserCommand(userDto));
        }

        [HttpPost("{userId:int}/User", Name = nameof(UpdateUser))]
        public Task<int> UpdateUser(
            [FromServices] UpdateUserCommandHandler handler,
            [FromBody] UserDto userDto,
            int userId)
        {
            return handler.Handle(new UpdateUserCommand(userId, userDto));
        }
    }
}
