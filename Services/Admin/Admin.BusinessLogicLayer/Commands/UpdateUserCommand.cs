using JumpIn.Admin.BusinessLogicLayer.Dtos;
using JumpIn.Common.Domain.BusinessLogicLayer;

namespace JumpIn.Admin.BusinessLogicLayer.Commands
{
    public class UpdateUserCommand : ICommand<int>
    {
        public UpdateUserCommand(int id, UserDto user)
        {
            Id = id;
            User = user;
        }

        public int Id { get; set; }

        public UserDto User { get; set; }
    }
}
