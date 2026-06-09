using SecureEmployeeManagementSystem.Domain.Entities;

namespace SecureEmployeeManagementSystem.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
}
