using JumpIn.Admin.BusinessLogicLayer.Dtos;
using JumpIn.Common.Domain.BusinessLogicLayer;

namespace JumpIn.Admin.BusinessLogicLayer.Commands
{
    public class CreateAdministratorCommand : ICommand<int>
    {
        public CreateAdministratorCommand(UserDto user)
        {
            User = user;
        }

        public UserDto User { get; set; }
    }
}
