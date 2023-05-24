using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Payment : BaseAuditableEntity
    {
        private Bid bid;

        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentTime { get; set; }

        [Required]
        public byte[] ProofOfPayment { get; set; }

        public int BidId { get; private set; }

        public Bid Bid
        {
            get => bid;

            set
            {
                bid = value;
                BidId = value is null ? throw new ArgumentNullException(nameof(Bid)) : value.BidId;
            }
        }
    }
}
