namespace WISE.Models.Auth
{
    public class LoginResponseDto
    {
        public required UserDto User { get; set; }
        public required TokensDto Tokens { get; set; }
    }

    public class UserDto
    {
        public required string Id { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string Role { get; set; }
    }

    public class TokensDto
    {
        public required TokenDto Access { get; set; }
        public required TokenDto Refresh { get; set; }
    }

    public class TokenDto
    {
        public required string Token { get; set; }
        public required string Expires { get; set; } 
    }
}
