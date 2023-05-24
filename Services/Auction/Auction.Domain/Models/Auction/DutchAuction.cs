using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class DutchAuction : BaseAuditableEntity
    {
        private Administrator administrator;
        private Seller seller;

        public int DutchAuctionId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The Title cannot exceed 25 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(128, ErrorMessage = "The Description cannot exceed 128 characters.")]
        public string Description { get; set; }

        public decimal StartPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal Decrement { get; set; }
        public DateTime EndTime { get; set; }
        public AuctionStatusEnum AuctionStatusId { get; set; }
        public AuctionStatus AuctionStatus { get; set; }

        public int AdministratorId { get; private set; }

        public Administrator Administrator
        {
            get => administrator;

            set
            {
                administrator = value;
                AdministratorId = value is null ? throw new ArgumentNullException(nameof(Administrator)) : value.AdministratorId;
            }
        }

        public int SellerId { get; private set; }

        public Seller Seller
        {
            get => seller;

            set
            {
                seller = value;
                SellerId = value is null ? throw new ArgumentNullException(nameof(Seller)) : value.SellerId;
            }
        }

        public Product? Product { get; set; }

        public ICollection<Bid> Bids { get; private set; }

        public void AddBid(Bid newBid)
        {
           Bids.Add(newBid);
        }
    }
}
