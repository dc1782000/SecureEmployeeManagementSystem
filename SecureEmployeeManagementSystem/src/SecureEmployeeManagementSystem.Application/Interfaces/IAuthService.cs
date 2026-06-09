using SecureEmployeeManagementSystem.Application.DTOs.Auth;

namespace SecureEmployeeManagementSystem.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
}