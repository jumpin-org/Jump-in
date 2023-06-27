using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Common.Domain.Models;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Seller: BaseDataModel
    {
        private Seller()
        {
        }

        public int AccountId { get; set; }
        
        public Account Account { get; set; }

        public IEnumerable<DutchAuction> DutchAuctions { get; } = new List<DutchAuction>();

        public static Seller Create(int accountId)
        {
            return new Seller
            {
                AccountId = accountId,
            };
        }
    }
}
