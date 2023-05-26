using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Common.Domain.Model;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Seller: BaseDataModel
    {
        public int AccountId { get; set; }
        
        public Account Account { get; set; }

        public IEnumerable<DutchAuction> DutchAuctions { get; } = new List<DutchAuction>();
    }
}
