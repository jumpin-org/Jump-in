namespace JumpIn.Authentication.API.Models
{
    public record AuthenticationToken(string Token, int ExpiresIn);
}
