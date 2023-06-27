using JumpIn.Auction.Domain.Contexts;
using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Common.Utility.Helpers;
using JumpIn.Common.Utility.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JumpIn.Auction.BusinessLogicLayer.QueryHandlers
{
    public class GetAllBiddersHandler : IQueryHandler<Task<List<string>>>
    {
        private readonly AuctionReadOnlyContext AuctionReadOnlyContext;
        private readonly ILogger<GetAllBiddersHandler> logger;

        public GetAllBiddersHandler(AuctionReadOnlyContext AuctionReadOnlyContext, ILogger<GetAllBiddersHandler> logger)
        {
            this.AuctionReadOnlyContext = AuctionReadOnlyContext;
            this.logger = logger;
        }

        public async Task<List<string>> Execute()
        {
            try
            {
                return AuctionReadOnlyContext.Set<Bidder>().Select(c => $"{c.Account.User.FullName}").ToList();
            }
            catch
            {
                logger.LogError(ExceptionMessages.COMMAND_HANDLER_ERROR.InvariantFormat(GetType().FullName));
                throw;
            }
        }
    }
}