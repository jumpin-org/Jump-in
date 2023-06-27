namespace JumpIn.Authentication.API.Models
{
    public record AuthenticationTokenDto(string Token, int ExpiresIn);
}
