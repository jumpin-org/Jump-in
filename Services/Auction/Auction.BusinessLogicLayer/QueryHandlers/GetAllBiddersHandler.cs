using JumpIn.Auction.Domain.Contexts;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Common.Domain.Helpers;
using JumpIn.Common.Exceptions;
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

        public async Task<List<string>> Handle()
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