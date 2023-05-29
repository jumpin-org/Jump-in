using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Admin.BusinessLogicLayer.Dtos
{
    public class UserDto
    {
        public UserDto(string name, string lastName, string email, string password, string address, string phoneNumber)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        private UserDto()
        {
        }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
