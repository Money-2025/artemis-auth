using Artemis.Auth.Application.Dtos;
using Artemis.Auth.Application.Dtos.Auth;
using Artemis.Auth.Application.Interfaces;
using Artemis.Auth.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Artemis.Auth.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<TokenDto>> Register([FromBody] RegisterDto dto)
    {
        // TODO: call _authService.RegisterAsync(dto, GetIpAddress())
        throw new NotImplementedException();
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenDto>> Login([FromBody] LoginDto dto)
    {
        // TODO: call _authService.LoginAsync(dto, GetIpAddress())
        throw new NotImplementedException();
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<TokenDto>> Refresh([FromBody] RefreshTokenRequestDto dto)
    {
        // TODO: call _authService.RefreshTokenAsync(dto.Token, GetIpAddress())
        throw new NotImplementedException();
    }

    [HttpPost("revoke")]
    public async Task<IActionResult> Revoke([FromBody] RevokeTokenRequestDto dto)
    {
        // TODO: call _authService.RevokeTokenAsync(dto.Token, GetIpAddress())
        throw new NotImplementedException();
    }

    // Helper method to retrieve client IP address
    private string GetIpAddress()
    {
        return HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";
    }

}