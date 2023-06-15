using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Admin.BusinessLogicLayer.Commands;
using Microsoft.Extensions.Logging;
using JumpIn.Common.Domain.Helpers;
using JumpIn.Admin.Domain.Contexts;
using JumpIn.Admin.Domain.Models.Admin;
using JumpIn.Common.Exceptions;
using System.Net;

namespace JumpIn.Admin.BusinessLogicLayer.CommandHandlers
{
    public class CreateAdministratorCommandHandler : ICommandHandler<CreateAdministratorCommand, int>
    {
        private readonly AdminWriteContext adminWriteContext;
        private readonly ILogger<CreateAdministratorCommandHandler> logger;

        public CreateAdministratorCommandHandler(AdminWriteContext adminWriteContext, ILogger<CreateAdministratorCommandHandler> logger)
        {
            this.adminWriteContext = adminWriteContext;
            this.logger = logger;
        }

        public async Task<int> Handle(CreateAdministratorCommand command)
        {
            try
            {
                command.CheckNotNull(nameof(command), logger);

                var newUser = User.Create(
                    command.User.Name,
                    command.User.LastName,
                    command.User.Email,
                    command.User.Password,
                    command.User.Address,
                    command.User.PhoneNumber);
                await adminWriteContext.SaveAsync(newUser);

                return newUser.Id;
            }
            catch
            {
                logger.LogError(ExceptionMessages.COMMAND_HANDLER_ERROR.InvariantFormat(GetType().FullName));
                throw;
            }
        }
    }
}
