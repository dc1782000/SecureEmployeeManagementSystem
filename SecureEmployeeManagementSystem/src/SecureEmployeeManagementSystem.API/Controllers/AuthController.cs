using Microsoft.AspNetCore.Mvc;
using SecureEmployeeManagementSystem.Application.Interfaces;
using SecureEmployeeManagementSystem.Application.DTOs.Auth;

namespace SecureEmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        var result = await _authService.LoginAsync(request);

        return Ok(new
        {
            result.Token,
            result.Username,
            result.Role
        });
    }
}