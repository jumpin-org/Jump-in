using JumpIn.Auction.BusinessLogicLayer.Dtos;
using JumpIn.Auction.BusinessLogicLayer.Queries;
using JumpIn.Auction.Domain.Contexts;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Common.Domain.Dtos.OutputDtos;
using JumpIn.Common.Domain.Helpers;
using JumpIn.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JumpIn.Auction.BusinessLogicLayer.QueryHandlers
{
    public class GetBidsHandler : IQueryHandler<GetBidsQuery, Task<List<BidOutputDto>>>
    {
        private readonly AuctionReadOnlyContext auctionReadOnlyContext;
        private readonly ILogger<GetBidsHandler> logger;

        public GetBidsHandler(AuctionReadOnlyContext AuctionReadOnlyContext, ILogger<GetBidsHandler> logger)
        {
            this.auctionReadOnlyContext = AuctionReadOnlyContext;
            this.logger = logger;
        }

        public async Task<List<BidOutputDto>> Execute(GetBidsQuery query)
        {
            try
            {
                return await auctionReadOnlyContext
                        .Set<Bid>()
                        .Where(c => c.DutchAuction.Id == query.AuctionId)
                        .OrderByDescending(c => c.Amount)
                        .Select(c =>
                            new BidOutputDto(
                                c.Id,
                                c.Amount,
                                c.BidTime,
                                c.BidStatus.Id
                            ))
                        .ToListAsync();
            }
            catch
            {
                logger.LogError(ExceptionMessages.COMMAND_HANDLER_ERROR.InvariantFormat(GetType().FullName));
                throw;
            }
        }
    }
}