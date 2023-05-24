namespace Admin.Domain.Modles
{
    public class Seller
    {
        public int SellerId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
