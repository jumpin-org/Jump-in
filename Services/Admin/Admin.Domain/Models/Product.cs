namespace Admin.Domain.Modles
{
    public class Product
    {
        public int ProductId { get; set; }
        public int AuctionId { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Size { get; set; }
        public decimal Weight { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public byte[] ThumbnailPhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Auction Auction { get; set; }
    }
}
