using JumpIn.Common.Domain.Model;

namespace JumpIn.Auction.Domain.Models.Admin
{
    public class Account : BaseAuditableEntity
    {
        private FicaDetail ficaDetail;
        private User user;

        public int AccountId { get; set; }

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

        public int FicaDetailId { get; private set; }

        public FicaDetail FicaDetail
        {
            get => ficaDetail;

            set
            {
                ficaDetail = value;
                FicaDetailId = value is null ? throw new ArgumentNullException(nameof(FicaDetail)) : value.FicaDetailId;
            }
        }
    }
}
