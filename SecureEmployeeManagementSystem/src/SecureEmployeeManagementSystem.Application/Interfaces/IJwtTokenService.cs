using SecureEmployeeManagementSystem.Domain.Entities;

namespace SecureEmployeeManagementSystem.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}