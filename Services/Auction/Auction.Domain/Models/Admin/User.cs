using JumpIn.Common.Domain.Model;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Auction.Domain.Models.Admin
{
    public class User : BaseAuditableEntity
    {
        [Required]
        [StringLength(64, ErrorMessage = "The Name value cannot exceed 64 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "The Last Name value cannot exceed 64 characters.")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public Administrator Administrator { get; set; }

        public Account Account { get; set; }
    }
}
