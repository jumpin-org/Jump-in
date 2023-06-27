using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Utility.Helpers;
using JumpIn.Common.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Admin.Domain.Models.Auction
{
    public class AuctionStatus: BaseStatusModel
    {
        private AuctionStatusEnum id;

        private AuctionStatus()
           : base()
        {
        }

        public AuctionStatusEnum Id
        {
            get => id;

            set
            {
                id = value;
                Name = value.GetEnumDescription();
            }
        }

        public IEnumerable<DutchAuction> DutchAuctions { get; } = new List<DutchAuction>();
    }
}
