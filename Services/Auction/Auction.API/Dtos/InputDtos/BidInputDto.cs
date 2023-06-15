using JumpIn.Common.Domain.Enums;

namespace JumpIn.Auction.API.Dtos.InputDtos
{
    public class BidInputDto
    {
        public decimal Amount { get; set; }

        public DateTime BidTime { get; set; }

        public int DutchAuctionId { get; set; }

        public int BidderId { get; set; }

        public BidStatusEnum BidStatus { get; set; } = BidStatusEnum.New;

    }
}
