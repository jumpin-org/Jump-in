using JumpIn.Common.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Auction.Domain.Models.Admin
{
    public class User : BaseAuditableEntity
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(24, ErrorMessage = "The Unique value cannot exceed 24 characters.")]
        public string UniqueEID { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "The Name value cannot exceed 64 characters.")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<Account> Accounts { get; private set; }

        public ICollection<Administrator> Administrators { get; private set; }


        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public void AddAdministrator(Administrator administrator)
        {
            Administrators.Add(administrator);
        }
    }
}
