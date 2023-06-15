using JumpIn.Admin.Domain.Models.Auction;
using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace JumpIn.Admin.Domain.Models.Admin
{
    public class Account : BaseAuditableEntity
    {
        private Account()
        {
        }

        public int UserId { get; private set; }

        public User User { get; private set; }

        public FicaDetail FicaDetail { get; private set; }

        public Seller Seller { get; private set; }

        public Bidder Bidder { get; private set; }

        public static Account Create(FicaDetail ficaDetail)
        {
            return new Account
            {
                FicaDetail = ficaDetail,
            };
        }
    }
}
