using JumpIn.Auction.API.Dtos.InputDtos;
using JumpIn.Auction.BusinessLogicLayer.CommandHandlers;
using JumpIn.Auction.BusinessLogicLayer.Commands;
using JumpIn.Auction.BusinessLogicLayer.Queries;
using JumpIn.Auction.BusinessLogicLayer.QueryHandlers;
using JumpIn.Common.Domain.Dtos.OutputDtos;
using Microsoft.AspNetCore.Mvc;

namespace JumpIn.Auction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionController : ControllerBase
    {
        [HttpGet("Bidders", Name = nameof(GetAllBidders))]
        public Task<List<string>> GetAllBidders(
            [FromServices] GetAllBiddersHandler handler)
        {
            return handler.Execute();
        }

        [HttpGet("{auctionId:int}/Bids", Name = nameof(GetBids))]
        public Task<List<BidOutputDto>> GetBids(
            [FromServices] GetBidsHandler handler,
            int auctionId)
        {
            return handler.Execute(new GetBidsQuery(auctionId));
        }

        [HttpPost("{accountId:int}/Bidder", Name = nameof(CreateBidder))]
        public Task<int> CreateBidder(
            [FromServices] CreateBidderCommandHandler handler,
            int accountId)
        {
            return handler.Handle(new CreateBidderCommand(accountId));
        }

        [HttpPost("{auctionId:int}/Bid", Name = nameof(CreateBid))]
        public Task<int> CreateBid(
            [FromServices] CreateBidCommandHandler handler,
            [FromBody] BidInputDto bid)
        {
            return handler.Handle(new CreateBidCommand(bid.BidderId, bid.DutchAuctionId, bid.Amount, bid.BidTime));
        }
    }
}