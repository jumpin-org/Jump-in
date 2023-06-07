using JumpIn.Admin.Domain.Contexts;
using JumpIn.Admin.Domain.Models.Admin;
using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Common.Domain.Helpers;
using JumpIn.Common.Exceptions;
using Microsoft.Extensions.Logging;

namespace JumpIn.Admin.BusinessLogicLayer.QueryHandlers
{
    public class GetAllUsersHandler : IQueryHandler<Task<List<string>>>
    {
        private readonly AdminReadOnlyContext adminReadOnlyContext;
        private readonly ILogger<GetAllUsersHandler> logger;

        public GetAllUsersHandler(AdminReadOnlyContext adminReadOnlyContext, ILogger<GetAllUsersHandler> logger)
        {
            this.adminReadOnlyContext = adminReadOnlyContext;
            this.logger = logger;
        }

        public async Task<List<string>> Handle()
        {
            try
            {
                return adminReadOnlyContext.Set<User>().Select(c => $"{c.Name} {c.LastName}").ToList();
            }
            catch
            {
                logger.LogError(ExceptionMessages.COMMAND_HANDLER_ERROR.InvariantFormat(GetType().FullName));
                throw;
            }
        }
    }
}