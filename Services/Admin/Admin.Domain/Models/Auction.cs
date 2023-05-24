namespace Admin.Domain.Modles
{
    public class Auction
    {
        public int AuctionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal StartPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal Decrement { get; set; }
        public DateTime EndTime { get; set; }
        public int SellerId { get; set; }
        public int AuctionStatusId { get; set; }
        public Seller Seller { get; set; }
        public AuctionStatus AuctionStatus { get; set; }
    }
}
