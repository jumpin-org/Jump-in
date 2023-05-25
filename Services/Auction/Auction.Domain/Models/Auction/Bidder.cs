using JumpIn.Auction.Domain.Models.Admin;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Bidder
    {
        public int BidderId { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

        public virtual ICollection<Bid> Bids { get; private set; }
    }
}
