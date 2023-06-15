using JumpIn.Admin.BusinessLogicLayer.Dtos;
using JumpIn.Common.Domain.BusinessLogicLayer;

namespace JumpIn.Admin.BusinessLogicLayer.Commands
{
    public class CreateAccountCommand : ICommand<int>
    {
        public CreateAccountCommand(UserDto user)
        {
            User = user;
        }

        public UserDto User { get; set; }
    }
}
