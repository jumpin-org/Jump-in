namespace JumpIn.Auction.Domain.Models.Admin
{
    public class Administrator
    {
        private User user;

        public int AdministratorId { get; set; }


        public int UserId { get; private set; }

        public User User
        {
            get => user;

            set
            {
                user = value;
                UserId = value is null ? throw new ArgumentNullException(nameof(User)) : value.UserId;
            }
        }
    }
}
