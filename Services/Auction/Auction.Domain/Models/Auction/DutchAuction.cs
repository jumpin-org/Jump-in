using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class DutchAuction : BaseAuditableEntity
    {
        private DutchAuction() 
        { }

        [Required]
        [StringLength(25, ErrorMessage = "The Title cannot exceed 25 characters.")]
        public string Title { get; private set; }

        [Required]
        [StringLength(128, ErrorMessage = "The Description cannot exceed 128 characters.")]
        public string Description { get; private set; }

        public decimal StartPrice { get; private set; }

        public decimal CurrentPrice { get; private set; }

        public decimal Decrement { get; private set; }

        public DateTime StartDateTime { get; private set; }

        public DateTime EndDateTime { get; private set; }

        public AuctionStatus AuctionStatus { get; private set; }

        public Product Product { get; private set; }

        public Administrator Administrator { get; private set; }

        public Seller Seller { get; private set; }

        public int? WinningBidId { get; private set; }

        public IEnumerable<Bid> Bids { get; } = new List<Bid>();

        public static DutchAuction Create(string title, string description, decimal startPrice, decimal currentPrice, decimal decrement, DateTime startDateTime, DateTime endDateTime, AuctionStatus auctionStatus)
        {
            return new DutchAuction()
            {
                Title = title,
                Description = description,
                StartPrice = startPrice,
                CurrentPrice = currentPrice,
                Decrement = decrement,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime,
                AuctionStatus = auctionStatus,
            };
        }

        public void SetProduct(Product product)
        {
            Product = product;
        }

        public void SetSeller(Seller seller)
        {
            Seller = seller;
        }

        public void SetAdministrator(Administrator administrator)
        {
            Administrator = administrator;
        }
    }
}
