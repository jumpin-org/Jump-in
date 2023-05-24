namespace Admin.Domain.Modles
{
    public class Bid
    {
        public int BidId { get; set; }
        public int AuctionId { get; set; }
        public int BidderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidTime { get; set; }
        public int BidStatusId { get; set; }
        public Auction Auction { get; set; }
        public Bidder Bidder { get; set; }
        public BidStatus BidStatus { get; set; }
    }
}
