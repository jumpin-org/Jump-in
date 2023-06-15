using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Common.Domain.Model;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Bidder : BaseDataModel
    {
        private Bidder()
        {
        }

        public int AccountId { get; set; }
        
        public Account Account { get; set; }

        public IEnumerable<Bid> Bids { get; } = new List<Bid>();

        public static Bidder Create(int accountId)
        {
            return new Bidder
            {
                AccountId = accountId,
            };
        }
    }
}
