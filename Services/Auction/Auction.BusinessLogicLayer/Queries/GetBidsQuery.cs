using JumpIn.Auction.BusinessLogicLayer.Dtos;
using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Common.Domain.Dtos.OutputDtos;

namespace JumpIn.Auction.BusinessLogicLayer.Queries
{
    public class GetBidsQuery : IQuery<Task<List<BidOutputDto>>>
    {
        public GetBidsQuery(int auctionId)
        {
            AuctionId = auctionId;
        }

        public int AuctionId { get; set; }
    }
}
