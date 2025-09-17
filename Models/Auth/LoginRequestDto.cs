namespace WISE.Models.Auth
{
    public class LoginRequestDto
    {
        public required string email { get; set; }
        public required string password { get; set; }
    }
}
