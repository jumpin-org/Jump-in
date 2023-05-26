using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Model;

namespace JumpIn.Admin.Domain.Models.Auction
{
    public class Bid : BaseAuditableEntity
    {
        public decimal Amount { get; set; }

        public DateTime BidTime { get; set; }

        public BidStatus BidStatus { get; set; }

        public DutchAuction DutchAuction { get; set; }

        public Bidder Bidder { get; set; }

        public IEnumerable<Payment> Payments { get; } = new List<Payment>();
    }
}
