namespace Admin.Domain.Modles
{
    public class Bidder
    {
        public int BidderId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
