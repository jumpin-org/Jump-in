using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Model;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Bid : BaseAuditableEntity
    {
        private DutchAuction dutchAuction;
        private Bidder bidder;

        public int BidId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidTime { get; set; }
        public BidStatusEnum BidStatusId { get; set; }
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

        public int DutchAuctionId { get; private set; }

        public DutchAuction DutchAuction
        {
            get => dutchAuction;

            set
            {
                dutchAuction = value;
                DutchAuctionId = value is null ? throw new ArgumentNullException(nameof(DutchAuction)) : value.DutchAuctionId;
            }
        }

        public ICollection<Payment> Payments { get; private set; }
    }
}
