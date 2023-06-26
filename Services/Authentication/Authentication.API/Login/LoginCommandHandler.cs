using JumpIn.Authentication.API.Contexts;
using JumpIn.Authentication.API.Models;
using JumpIn.Authentication.API.Services;
using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Common.Domain.Helpers;
using JumpIn.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Authentication.API.Login
{
    public sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly AuthContext authContext;
        private readonly JwtProvider jwtProvider;
        private readonly ILogger<LoginCommandHandler> logger;

        public LoginCommandHandler(AuthContext authContext, JwtProvider jwtProvider, ILogger<LoginCommandHandler> logger)
        {
            this.authContext = authContext;
            this.jwtProvider = jwtProvider;
            this.logger = logger;
        }

        public async Task<string> Handle(LoginCommand command)
        {
            try
            {
                command.CheckNotNull(nameof(command), logger);

                User? user = await authContext.Set<User>().Where(c => c.Email == command.email 
                                                              && c.Password == command.password).FirstOrDefaultAsync();

                if(user is null)
                {
                    return string.Empty;
                }

                string _token = jwtProvider.Generate(user);

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
