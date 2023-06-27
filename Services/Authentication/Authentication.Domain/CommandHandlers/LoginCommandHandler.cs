using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Common.Utility.Helpers;
using JumpIn.Common.Utility.Exceptions;
using Microsoft.EntityFrameworkCore;
using JumpIn.Authentication.Domain.Commands;
using Microsoft.Extensions.Logging;
using JumpIn.Authentication.Domain.Contexts;
using JumpIn.Authentication.Domain.Models;
using JumpIn.Common.Utility.Helpers.AuthHelpers;
using JumpIn.Common.Domain.Dtos.OutputDto;

namespace JumpIn.Authentication.Domain.CommandHandlers
{
    public sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private AuthReadOnlyContext authReadOnlyContext;
        private readonly ILogger<LoginCommandHandler> logger;

        public LoginCommandHandler(AuthReadOnlyContext authReadOnlyContext, ILogger<LoginCommandHandler> logger)
        {
            this.authReadOnlyContext = authReadOnlyContext;
            this.logger = logger;
        }

        public async Task<string> Handle(LoginCommand command)
        {
            try
            {
                command.CheckNotNull(nameof(command), logger);

                User? user = await authReadOnlyContext.Set<User>().Where(c => c.Email == command.email 
                                                              && c.Password == command.password).FirstOrDefaultAsync();

                if(user is null)
                {
                    return string.Empty;
                }

                string _token = new JwtProvider().Generate(new AuthUserDto(user.Id.ToString(), user.Email));

                return _token;
            }
            catch
            {
                logger.LogError(ExceptionMessages.COMMAND_HANDLER_ERROR.InvariantFormat(GetType().FullName));
                throw;
            }
        }
    }
}
