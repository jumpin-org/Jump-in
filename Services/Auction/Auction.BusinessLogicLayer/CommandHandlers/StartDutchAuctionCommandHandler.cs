using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Auction.BusinessLogicLayer.Commands;
using Microsoft.Extensions.Logging;
using JumpIn.Common.Domain.Helpers;
using JumpIn.Auction.Domain.Contexts;
using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Common.Exceptions;
using System.Net;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Auction.BusinessLogicLayer.Dtos;
using JumpIn.Common.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JumpIn.Auction.BusinessLogicLayer.CommandHandlers
{
    public class StartDutchAuctionCommandHandler : ICommandHandler<StartDutchAuctionCommand, int>
    {
        private readonly AuctionWriteContext auctionWriteContext;
        private readonly ILogger<CreateDutchAuctionCommandHandler> logger;

        public StartDutchAuctionCommandHandler(AuctionWriteContext auctionWriteContext, ILogger<CreateDutchAuctionCommandHandler> logger)
        {
            this.auctionWriteContext = auctionWriteContext;
            this.logger = logger;
        }

        public async Task<int> Handle(StartDutchAuctionCommand command)
        {
            try
            {
                command.CheckNotNull(nameof(command), logger);

                var dutchAuction = await auctionWriteContext.GetEntityByIdAsync<DutchAuction>(command.AuctionId);
                dutchAuction.CheckNotNull(nameof(dutchAuction), logger);

                var auctionStatus = await auctionWriteContext.Set<AuctionStatus>().FirstAsync(c => c.Id == AuctionStatusEnum.Started);
                auctionStatus.CheckNotNull(nameof(auctionStatus), logger);

                dutchAuction.UpdateAuctionStatus(auctionStatus);

                await auctionWriteContext.SaveAsync(dutchAuction);

                return dutchAuction.Id;
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message); 
                logger.LogError(ExceptionMessages.COMMAND_HANDLER_ERROR.InvariantFormat(GetType().FullName));
                throw;
            }
        }
    }
}
