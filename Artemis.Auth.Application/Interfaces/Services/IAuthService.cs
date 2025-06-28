using Artemis.Auth.Application.Dtos.Auth;

namespace Artemis.Auth.Application.Interfaces.Services;

public interface IAuthService
{
    Task<TokenDto> RegisterAsync(RegisterDto dto, string ipAddress);
    Task<TokenDto> LoginAsync(LoginDto dto, string ipAddress);
    Task<TokenDto> RefreshTokenAsync(string token, string ipAddress);
    Task RevokeTokenAsync(string token, string ipAddress);
}