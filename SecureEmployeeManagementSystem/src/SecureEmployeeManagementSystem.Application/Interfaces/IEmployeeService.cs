using SecureEmployeeManagementSystem.Application.DTOs;

namespace SecureEmployeeManagementSystem.Application.Interfaces;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllAsync();
    Task<EmployeeDto?> GetByIdAsync(Guid id);
    Task<List<EmployeeDto>> SearchAsync(string? keyword, string? department, string? designation, bool? isActive);
    Task<Guid> CreateAsync(CreateEmployeeDto dto);
    Task UpdateAsync(Guid id, CreateEmployeeDto dto);
    Task DeleteAsync(Guid id);
    Task<EmployeeDashboardDto> GetDashboardAsync();
}