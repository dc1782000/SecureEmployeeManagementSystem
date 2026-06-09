using Microsoft.EntityFrameworkCore;
using SecureEmployeeManagementSystem.Application.Interfaces;
using SecureEmployeeManagementSystem.Domain.Entities;
using SecureEmployeeManagementSystem.Persistence.Context;

namespace SecureEmployeeManagementSystem.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)

    {

        _context = context;

    }
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users

            .FirstOrDefaultAsync(u => u.Username == username);
    }
}