using Microsoft.EntityFrameworkCore;
using SecureEmployeeManagementSystem.Application.DTOs;
using SecureEmployeeManagementSystem.Application.Interfaces;
using SecureEmployeeManagementSystem.Domain.Entities;
using SecureEmployeeManagementSystem.Persistence.Context;

namespace SecureEmployeeManagementSystem.Infrastructure.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetByIdAsync(Guid id)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == id);
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Employee>> SearchAsync(
        string? keyword,
        string? department,
        string? designation,
        bool? isActive)
    {
        var query = _context.Employees.AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            query = query.Where(e =>
                EF.Functions.Like(e.FirstName, $"%{keyword}%") ||
                EF.Functions.Like(e.LastName, $"%{keyword}%") ||
                EF.Functions.Like(e.EmployeeCode, $"%{keyword}%") ||
                EF.Functions.Like(e.Email, $"%{keyword}%")
            );
        }

        if (!string.IsNullOrWhiteSpace(department))
        {
            query = query.Where(e => e.Department == department);
        }

        if (!string.IsNullOrWhiteSpace(designation))
        {
            query = query.Where(e => e.Designation == designation);
        }

        if (isActive.HasValue)
        {
            query = query.Where(e => e.IsActive == isActive.Value);
        }
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(Employee employee)
    {
        employee.CreatedOn = DateTime.UtcNow;

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee employee)
    {
        var existing = await _context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

        if (existing == null)
            throw new Exception("Employee not found");

        existing.EmployeeCode = employee.EmployeeCode;
        existing.FirstName = employee.FirstName;
        existing.LastName = employee.LastName;
        existing.Email = employee.Email;
        existing.Department = employee.Department;
        existing.Designation = employee.Designation;
        existing.JoiningDate = employee.JoiningDate;
        existing.IsActive = employee.IsActive;
        existing.ModifiedOn = DateTime.UtcNow;

        _context.Employees.Update(existing);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Employee employee)
    {
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }
    
    public async Task<EmployeeDashboardDto> GetDashboardAsync()
    {
        var total = await _context.Employees.CountAsync();
        var active = await _context.Employees.CountAsync(e => e.IsActive);
        var inactive = await _context.Employees.CountAsync(e => !e.IsActive);

        return new EmployeeDashboardDto
        {
            TotalEmployees = total,
            ActiveEmployees = active,
            InactiveEmployees = inactive
        };
    }
}