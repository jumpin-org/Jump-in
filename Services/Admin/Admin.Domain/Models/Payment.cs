namespace Admin.Domain.Modles
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BidId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentTime { get; set; }
        public byte[] ProofOfPayment { get; set; }
        public Bid Bid { get; set; }
    }
}
