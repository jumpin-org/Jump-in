using JumpIn.Common.Domain.Model;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Bid : BaseAuditableEntity
    {
        private DutchAuction auction;
        private Bidder bidder;

        public int BidId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidTime { get; set; }
        public int BidStatusId { get; set; }
        public BidStatus BidStatus { get; set; }

        public int BidderId { get; private set; }

        public Bidder Bidder
        {
            get => bidder;

            set
            {
                bidder = value;
                BidderId = value is null ? throw new ArgumentNullException(nameof(Bidder)) : value.BidderId;
            }
        }

        public int AuctionId { get; private set; }

        public DutchAuction Auction
        {
            get => auction;

            set
            {
                auction = value;
                AuctionId = value is null ? throw new ArgumentNullException(nameof(Auction)) : value.AuctionId;
            }
        }
    }
}
