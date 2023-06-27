using JumpIn.Auction.BusinessLogicLayer.Dtos;
using JumpIn.Auction.BusinessLogicLayer.Queries;
using JumpIn.Auction.Domain.Contexts;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Common.Domain.Dtos.OutputDtos;
using JumpIn.Common.Utility.Helpers;
using JumpIn.Common.Utility.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Drawing;

namespace JumpIn.Auction.BusinessLogicLayer.QueryHandlers
{
    public class GetDutchAuctionsHandler : IQueryHandler<Task<List<DutchAuctionOutputDto>>>
    {
        private readonly AuctionReadOnlyContext auctionReadOnlyContext;
        private readonly ILogger<GetBidsHandler> logger;

        public GetDutchAuctionsHandler(AuctionReadOnlyContext AuctionReadOnlyContext, ILogger<GetBidsHandler> logger)
        {
            this.auctionReadOnlyContext = AuctionReadOnlyContext;
            this.logger = logger;
        }

        public async Task<List<DutchAuctionOutputDto>> Execute()
        {
            try
            {
                return await auctionReadOnlyContext
                        .Set<DutchAuction>()
                        .OrderBy(c => c.StartDateTime)
                        .Select(c =>
                            new DutchAuctionOutputDto(
                                c.Id,
                                c.Title,
                                c.Description,
                                c.StartPrice,
                                c.CurrentPrice,
                                c.StartDateTime,
                                c.EndDateTime,
                                new ProductOutputDto(
                                        c.Product.ProductName,
                                        c.Product.ProductNumber,
                                        c.Product.Color,
                                        c.Product.Size,
                                        c.Product.Weight,
                                        c.Product.CurrentPrice,
                                        c.Product.DiscontinuedDate,
                                        c.Product.ThumbnailPhoto,
                                        c.Product.ThumbnailPhotoFileName,
                                        c.Product.AdditionalDetail)
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
