using JumpIn.Auction.Domain.Models.Admin;

namespace JumpIn.Auction.Domain.Models.Auction
{
    public class Bidder
    {
        private Account account;

        public int BidderId { get; set; }

        public int AccountId { get; private set; }

        public Account Account
        {
            get => account;

            set
            {
                account = value;
                AccountId = value is null ? throw new ArgumentNullException(nameof(Account)) : value.AccountId;
            }
        }

        public ICollection<Bid> Bids { get; private set; }
    }
}
