using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace JumpIn.Auction.Domain.Models.Admin
{
    public class Account : BaseAuditableEntity
    {
        public int AccountId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public FicaDetail FicaDetail { get; set; }

        public ICollection<Seller> Sellers { get; private set; }
        public ICollection<Bidder> Bidders { get; private set; }
    }
}
