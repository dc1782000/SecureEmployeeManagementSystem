using SecureEmployeeManagementSystem.Application.DTOs;
using SecureEmployeeManagementSystem.Domain.Entities;

namespace SecureEmployeeManagementSystem.Application.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee?> GetByIdAsync(Guid id);
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<IEnumerable<Employee>> SearchAsync(
        string? keyword,
        string? department,
        string? designation,
        bool? isActive
    );
    Task AddAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(Employee employee);
    Task<EmployeeDashboardDto> GetDashboardAsync();
}