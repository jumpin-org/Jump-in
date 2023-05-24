using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Payment : BaseAuditableEntity
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentTime { get; set; }

        [Required]
        public byte[] ProofOfPayment { get; set; }

        public int BidId { get; set; }

        public Bid Bid { get; set; }
    }
}
