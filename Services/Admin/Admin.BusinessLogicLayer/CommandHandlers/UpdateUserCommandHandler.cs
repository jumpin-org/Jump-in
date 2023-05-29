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
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, int>
    {
        private readonly AdminWriteContext adminWriteContext;
        private readonly ILogger<UpdateUserCommandHandler> logger;

        public UpdateUserCommandHandler(AdminWriteContext adminWriteContext, ILogger<UpdateUserCommandHandler> logger)
        {
            this.adminWriteContext = adminWriteContext;
            this.logger = logger;
        }

        public async Task<int> Execute(UpdateUserCommand command)
        {
            try
            {
                command.CheckNotNull(nameof(command), logger);

                var existingUser = adminWriteContext.Set<User>().FirstOrDefault(x => x.Id == command.Id);

                if (existingUser is not null)
                {
                    existingUser.Update(
                    command.User.Name,
                    command.User.LastName,
                    command.User.Email,
                    command.User.Password,
                    command.User.Address,
                    command.User.PhoneNumber);
                    await adminWriteContext.SaveAsync(existingUser);
                    return existingUser.Id ;
                }

                throw new NullReferenceException();
            }
            catch(Exception ex)
            {
                logger.LogError(ExceptionMessages.COMMAND_HANDLER_ERROR.InvariantFormat(ex.Message));
                throw;
            }
        }
    }
}
