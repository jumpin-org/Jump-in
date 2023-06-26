using JumpIn.Authentication.API.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;

namespace JumpIn.Authentication.API.Services
{
    public sealed class JwtProvider
    {
        public string Generate(User user)
        {
            var claims = new Claim[]
            { 
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email),
            };

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secret-key"));
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
