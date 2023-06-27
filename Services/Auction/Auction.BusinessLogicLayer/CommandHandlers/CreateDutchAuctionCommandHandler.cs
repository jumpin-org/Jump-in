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

namespace JumpIn.Auction.BusinessLogicLayer.CommandHandlers
{
    public class CreateDutchAuctionCommandHandler : ICommandHandler<CreateDutchAuctionCommand, int>
    {
        private readonly AuctionWriteContext auctionWriteContext;
        private readonly ILogger<CreateDutchAuctionCommandHandler> logger;

        public CreateDutchAuctionCommandHandler(AuctionWriteContext auctionWriteContext, ILogger<CreateDutchAuctionCommandHandler> logger)
        {
            this.auctionWriteContext = auctionWriteContext;
            this.logger = logger;
        }

        public async Task<int> Handle(CreateDutchAuctionCommand command)
        {
            try
            {
                command.CheckNotNull(nameof(command), logger);

                var auctionStatus = await auctionWriteContext.Set<AuctionStatus>().FirstAsync(c => c.Id == AuctionStatusEnum.New);

                var newAuction = DutchAuction.Create(
                    command.Title,
                    command.Description,
                    command.StartPrice,
                    command.CurrentPrice,
                    command.Decrement,
                    command.StartDateTime,
                    command.EndDateTime,
                    auctionStatus
                   );

                var defualtAdministrator = await auctionWriteContext.Set<Administrator>().FirstAsync(c => c.Id == 1);
                newAuction.SetAdministrator(defualtAdministrator);

                var account = await auctionWriteContext.GetEntityByIdAsync<Account>(command.AccountId);
                newAuction.SetSeller(account.Seller ?? Seller.Create(command.AccountId));

                newAuction.SetProduct(
                    Product.Create(
                    command.ProductName,
                    command.ProductNumber,
                    command.Color,
                    command.Size,
                    command.Weight,
                    command.CurrentProductPrice,
                    command.DiscontinuedDate,
                    command.ThumbnailPhoto ?? new byte[0],
                    command.ThumbnailPhotoFileName,
                    command.AdditionalDetail
                    ));


                await auctionWriteContext.SaveAsync(newAuction);

                return newAuction.Id;
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
