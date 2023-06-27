using JumpIn.Common.Domain.Dtos.OutputDto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JumpIn.Common.Utility.Helpers.AuthHelpers
{
    public sealed class JwtProvider
    {
        public string Generate(AuthUserDto user)
        {
            var claims = new Claim[]
            { 
                new(JwtRegisteredClaimNames.Sub, user.UniqueIdentifier),
                new(JwtRegisteredClaimNames.Email, user.Email),
            };

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secret-keysecret-keysecret-key"));
            var signingCredentials =  new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              "issuer",
              "audience",
              claims,
              null,
              DateTime.UtcNow.AddHours(1),
              signingCredentials);

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
