using JumpIn.Admin.Domain.Models.Admin;
using JumpIn.Common.Domain.Models;

namespace JumpIn.Admin.Domain.Models.Auction
{
    public class Bidder : BaseDataModel
    {
        public int AccountId { get; set; }
        
        public Account Account { get; set; }

        public IEnumerable<Bid> Bids { get; } = new List<Bid>();
    }
}
