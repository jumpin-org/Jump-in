using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Model;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Bid : BaseAuditableEntity
    {
        public int BidId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidTime { get; set; }
        public BidStatusEnum BidStatusId { get; set; }
        public BidStatus BidStatus { get; set; }

        public int BidderId { get; set; }

        public Bidder Bidder { get; set; }

        public int DutchAuctionId { get; set; }

        public DutchAuction DutchAuction { get; set; }

        public ICollection<Payment> Payments { get; private set; }
    }
}
