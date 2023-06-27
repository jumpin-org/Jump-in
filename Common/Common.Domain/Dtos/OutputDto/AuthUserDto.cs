using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Common.Domain.Dtos.OutputDto
{
    public class AuthUserDto
    {
        public AuthUserDto(string uniqueIdentifier, string email)
        {
            UniqueIdentifier = uniqueIdentifier;
            Email = email;
        }

        public string UniqueIdentifier { get; set; }

        public string Email { get; set; }

    }
}
