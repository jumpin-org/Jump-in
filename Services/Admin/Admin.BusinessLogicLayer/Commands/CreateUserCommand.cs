using JumpIn.Admin.BusinessLogicLayer.Dtos;
using JumpIn.Common.Domain.BusinessLogicLayer;

namespace JumpIn.Admin.BusinessLogicLayer.Commands
{
    public class CreateUserCommand : ICommand<int>
    {
        public CreateUserCommand(UserDto user)
        {
            User = user;
        }

        public UserDto User { get; set; }
    }
}
