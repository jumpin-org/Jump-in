using JumpIn.Admin.Domain.Models.Auction;
using JumpIn.Common.Domain.Model;

namespace JumpIn.Admin.Domain.Models.Admin
{
    public class Administrator : BaseDataModel
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public IEnumerable<DutchAuction> DutchAuctions { get; } = new List<DutchAuction>();
    }
}
