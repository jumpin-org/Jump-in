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
    public class BidderController : Controller
    {
        [HttpGet("Bidders", Name = nameof(GetAllBidders))]
        public Task<List<string>> GetAllBidders(
            [FromServices] GetAllBiddersHandler handler)
        {
            return handler.Execute();
        }

        [HttpPost("{accountId:int}/Bidder", Name = nameof(CreateBidder))]
        public Task<int> CreateBidder(
            [FromServices] CreateBidderCommandHandler handler,
            int accountId)
        {
            return handler.Handle(new CreateBidderCommand(accountId));
        }
    }
}
