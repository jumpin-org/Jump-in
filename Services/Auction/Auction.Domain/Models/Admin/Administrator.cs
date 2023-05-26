using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.Model;

namespace JumpIn.Auction.Domain.Models.Admin
{
    public class Administrator : BaseDataModel
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public IEnumerable<DutchAuction> DutchAuctions { get; } = new List<DutchAuction>();
    }
}
