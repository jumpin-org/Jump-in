using JumpIn.Auction.API.Dtos.InputDtos;
using JumpIn.Auction.BusinessLogicLayer.CommandHandlers;
using JumpIn.Auction.BusinessLogicLayer.Commands;
using JumpIn.Auction.BusinessLogicLayer.QueryHandlers;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.Dtos.OutputDtos;
using Microsoft.AspNetCore.Mvc;

namespace JumpIn.Auction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionController : Controller
    {
        [HttpGet("DutchAuctions", Name = nameof(GetDutchAuctions))]
        public Task<List<DutchAuctionOutputDto>> GetDutchAuctions(
            [FromServices] GetDutchAuctionsHandler handler)
        {
            return handler.Execute();
        }

        [HttpPost("Create", Name = nameof(CreateDutchAuction))]
        public Task<int> CreateDutchAuction(
            [FromServices] CreateDutchAuctionCommandHandler handler,
            [FromBody] CreateDutchAuctionCommand createDutchAuctionCommand)
        {
            return handler.Handle(createDutchAuctionCommand);
        }
    }
}