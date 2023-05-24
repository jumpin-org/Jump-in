namespace Admin.Domain.Modles
{
    public class Account
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public int FicaId { get; set; }
        public User User { get; set; }
        public FicaDetail FicaDetail { get; set; }
    }
}
