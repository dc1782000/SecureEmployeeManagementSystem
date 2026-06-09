using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using SecureEmployeeManagementSystem.Application.Interfaces;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId =>
        _httpContextAccessor.HttpContext?.User?
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;

    public string? UserName =>
        _httpContextAccessor.HttpContext?.User?
            .FindFirst(ClaimTypes.Name)?.Value;
}