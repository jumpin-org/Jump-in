using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class DutchAuction : BaseAuditableEntity
    {
        [Required]
        [StringLength(25, ErrorMessage = "The Title cannot exceed 25 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(128, ErrorMessage = "The Description cannot exceed 128 characters.")]
        public string Description { get; set; }

        public decimal StartPrice { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal Decrement { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public AuctionStatus AuctionStatus { get; set; }

        public Product Product { get; set; }

        public Administrator Administrator { get; set; }

        public Seller Seller { get; set; }

        public Bid WinningBid { get; set; }

        public IEnumerable<Bid> Bids { get; } = new List<Bid>();
    }
}
