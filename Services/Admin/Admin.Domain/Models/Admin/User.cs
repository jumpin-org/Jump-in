using JumpIn.Common.Domain.Model;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace JumpIn.Admin.Domain.Models.Admin
{
    public class User : BaseAuditableEntity
    {
        private User()
        {
        }

        [Required]
        [StringLength(64, ErrorMessage = "The Name value cannot exceed 64 characters.")]
        public string Name { get; private set; }

        [Required]
        [StringLength(64, ErrorMessage = "The Last Name value cannot exceed 64 characters.")]
        public string LastName { get; private set; }

        [Required]
        public string Email { get; private set; }

        [Required]
        public string Password { get; private set; }

        [Required]
        public string Address { get; private set; }

        [Required]
        public string PhoneNumber { get; private set; }

        public Administrator Administrator { get; private set; }

        public Account Account { get; private set; }

        public string FullName { get { return $"{Name} {LastName}"; } }

        public static User Create(string name, string lastName, string email, string password, string address, string phoneNumber)
        {
            return new User
            {
                Name = name,
                LastName = lastName,
                Email = email,
                Password = password,
                Address = address,
                PhoneNumber = phoneNumber,
            };
        }

        public void Update(string name, string lastName, string email, string password, string address, string phoneNumber)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }
    }
}
