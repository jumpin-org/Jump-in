using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Helpers;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class AuctionStatus
    {
        private AuctionStatusEnum auctionStatusId;

        private AuctionStatus()
        {
        }

        public AuctionStatusEnum AuctionStatusId
        {
            get => auctionStatusId;

            set
            {
                auctionStatusId = value;
                Name = value.GetEnumDescription();
            }
        }

        [StringLength(25, ErrorMessage = "The Name value cannot exceed 25 characters.")]
        public string Name { get; set; }

        [StringLength(128, ErrorMessage = "The Description value cannot exceed 128 characters.")]
        public string Description { get; private set; }

        public virtual ICollection<DutchAuction> DutchAuctions { get; private set; }
    }
}
