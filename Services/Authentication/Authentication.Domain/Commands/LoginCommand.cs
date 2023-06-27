using JumpIn.Common.Domain.BusinessLogicLayer;

namespace JumpIn.Authentication.Domain.Commands
{
    public record LoginCommand(string email, string password): ICommand<string>;
}
