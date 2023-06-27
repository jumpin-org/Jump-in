using JumpIn.Admin.Domain.Models.Auction;
using JumpIn.Common.Domain.Models;

namespace JumpIn.Admin.Domain.Models.Admin
{
    public class Administrator : BaseDataModel
    {
        public int UserId { get; private set; }

        public User User { get; private set; }

        public IEnumerable<DutchAuction> DutchAuctions { get; } = new List<DutchAuction>();
    }
}
