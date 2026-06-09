using Microsoft.EntityFrameworkCore;
using SecureEmployeeManagementSystem.Domain.Entities;

namespace SecureEmployeeManagementSystem.Persistence.Context;
public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<User> Users => Set<User>();
}