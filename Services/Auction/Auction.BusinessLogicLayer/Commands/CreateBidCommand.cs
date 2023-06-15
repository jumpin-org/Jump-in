using JumpIn.Auction.BusinessLogicLayer.Dtos;
using JumpIn.Common.Domain.BusinessLogicLayer;
using JumpIn.Common.Domain.Enums;

namespace JumpIn.Auction.BusinessLogicLayer.Commands
{
    public class CreateBidCommand : ICommand<int>
    {
        public CreateBidCommand(int bidderId, int dutchAuctionId, decimal amount, DateTime bidTime)
        {
            BidderId = bidderId;
            DutchAuctionId = dutchAuctionId;
            Amount = amount;
            BidTime = bidTime;
        }

        public int BidderId { get; set; }

        public int DutchAuctionId { get; set; }

        public decimal Amount { get; set; }

        public DateTime BidTime { get; set; }
    }
}
