using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Auction.BusinessLogicLayer.Commands;
using Microsoft.Extensions.Logging;
using JumpIn.Common.Utility.Helpers;
using JumpIn.Auction.Domain.Contexts;
using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Common.Utility.Exceptions;
using System.Net;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Auction.BusinessLogicLayer.Dtos;
using JumpIn.Common.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using JumpIn.Common.Utility.Exceptions;

namespace JumpIn.Auction.BusinessLogicLayer.CommandHandlers
{
    public class CreateBidCommandHandler : ICommandHandler<CreateBidCommand, int>
    {
        private readonly AuctionWriteContext auctionWriteContext;
        private readonly ILogger<CreateBidCommandHandler> logger;

        public CreateBidCommandHandler(AuctionWriteContext auctionWriteContext, ILogger<CreateBidCommandHandler> logger)
        {
            this.auctionWriteContext = auctionWriteContext;
            this.logger = logger;
        }

        public async Task<int> Handle(CreateBidCommand command)
        {
            try
            {
                command.CheckNotNull(nameof(command), logger);

                var dutchAuction = await auctionWriteContext.GetEntityByIdAsync<DutchAuction>(command.DutchAuctionId);
                var bidder = await auctionWriteContext.GetEntityByIdAsync<Bidder>(command.BidderId);
                var bidStatus = await auctionWriteContext.Set<BidStatus>().FirstAsync( c => c.Id == BidStatusEnum.Placed);
 
                var newBid = Bid.Create(
                    command.Amount,
                    command.BidTime,
                    bidStatus,
                    dutchAuction,
                    bidder
                   );

                await auctionWriteContext.SaveAsync(newBid);

                return newBid.Id;
            }
            catch
            {
                logger.LogError(ExceptionMessages.COMMAND_HANDLER_ERROR.InvariantFormat(GetType().FullName));
                throw;
            }
        }
    }
}
