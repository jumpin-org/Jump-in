using JumpIn.Common.Domain.BusinessLogicLayer;

namespace JumpIn.Authentication.API.Login
{
    public record LoginCommand(string email, string password): ICommand<string>;
}
