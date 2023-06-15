using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Model;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Bid : BaseAuditableEntity
    {
        private Bid()
        {
        }

        public decimal Amount { get; set; }

        public DateTime BidTime { get; set; }

        public BidStatus BidStatus { get; set; }

        public DutchAuction DutchAuction { get; set; }

        public Bidder Bidder { get; set; }

        public IEnumerable<Payment> Payments { get; } = new List<Payment>();

        public static Bid Create(decimal amount, DateTime bidTime, BidStatus bidStatus, DutchAuction dutchAuction, Bidder bidder)
        {
            return new Bid
            {
                Amount = amount,
                BidTime = bidTime,
                BidStatus = bidStatus,
                DutchAuction = dutchAuction,
                Bidder = bidder,
            };
        }
    }
}
