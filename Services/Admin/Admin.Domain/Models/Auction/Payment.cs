using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Admin.Domain.Models.Auction
{
    public class Payment : BaseAuditableEntity
    {
        public decimal Amount { get; set; }

        public DateTime PaymentTime { get; set; }

        public byte[] ProofOfPayment { get; set; }

        public Bid Bid { get; set; }
    }
}
