using JumpIn.Auction.Domain.Models.Admin;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Seller
    {
        public int SellerId { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

        public virtual ICollection<DutchAuction> DutchAuctions { get; private set; }
    }
}
