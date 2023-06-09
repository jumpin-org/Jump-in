using JumpIn.Auction.BusinessLogicLayer.QueryHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

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
            return handler.Handle();
        }
    }
}