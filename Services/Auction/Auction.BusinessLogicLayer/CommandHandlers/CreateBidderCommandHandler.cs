using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Auction.BusinessLogicLayer.Commands;
using Microsoft.Extensions.Logging;
using JumpIn.Common.Utility.Helpers;
using JumpIn.Auction.Domain.Contexts;
using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Common.Utility.Exceptions;
using System.Net;
using JumpIn.Auction.Domain.Models.Auction;

namespace JumpIn.Auction.BusinessLogicLayer.CommandHandlers
{
    public class CreateBidderCommandHandler : ICommandHandler<CreateBidderCommand, int>
    {
        private readonly AuctionWriteContext auctionWriteContext;
        private readonly ILogger<CreateBidderCommandHandler> logger;

        public CreateBidderCommandHandler(AuctionWriteContext auctionWriteContext, ILogger<CreateBidderCommandHandler> logger)
        {
            this.auctionWriteContext = auctionWriteContext;
            this.logger = logger;
        }

        public async Task<int> Handle(CreateBidderCommand command)
        {
            try
            {
                command.CheckNotNull(nameof(command), logger);

                var newBidder = Bidder.Create(command.AccountId);
                await auctionWriteContext.SaveAsync(newBidder);

                return newBidder.Id;
            }
            catch
            {
                logger.LogError(ExceptionMessages.COMMAND_HANDLER_ERROR.InvariantFormat(GetType().FullName));
                throw;
            }
        }
    }
}
