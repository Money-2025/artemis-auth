namespace Artemis.Auth.Application.Dtos.Auth;

public class LoginDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}