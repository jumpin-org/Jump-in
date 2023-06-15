using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Admin.BusinessLogicLayer.Commands;
using Microsoft.Extensions.Logging;
using JumpIn.Common.Domain.Helpers;
using JumpIn.Admin.Domain.Contexts;
using JumpIn.Admin.Domain.Models.Admin;
using JumpIn.Common.Exceptions;
using System.Net;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using JumpIn.Common.Domain.Enums;

namespace JumpIn.Admin.BusinessLogicLayer.CommandHandlers
{
    public class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand, int>
    {
        private readonly AdminWriteContext adminWriteContext;
        private readonly ILogger<CreateAccountCommandHandler> logger;

        public CreateAccountCommandHandler(AdminWriteContext adminWriteContext, ILogger<CreateAccountCommandHandler> logger)
        {
            this.adminWriteContext = adminWriteContext;
            this.logger = logger;
        }

        public async Task<int> Handle(CreateAccountCommand command)
        {
            try
            {
                command.CheckNotNull(nameof(command), logger);

                var ficaStatus = await adminWriteContext.Set<FicaStatus>().FirstAsync(c => c.Id == FicaStatusEnum.NotStarted);
                var ficaDetail = FicaDetail.Create(
                    command.IDDocument,
                    command.ProofAddress,
                    ficaStatus
                    );

                var newUser = User.Create(
                    command.Name,
                    command.LastName,
                    command.Email,
                    command.Password,
                    command.Address,
                    command.PhoneNumber);

                newUser.SetAccount(Account.Create(ficaDetail));

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
