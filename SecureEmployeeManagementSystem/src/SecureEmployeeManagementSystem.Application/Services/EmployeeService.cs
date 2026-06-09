using SecureEmployeeManagementSystem.Application.DTOs;
using SecureEmployeeManagementSystem.Application.Interfaces;
using SecureEmployeeManagementSystem.Domain.Entities;

namespace SecureEmployeeManagementSystem.Application.Services;
public class EmployeeService: IEmployeeService
{
    private readonly IEmployeeRepository _repo;
    private readonly ICurrentUserService _currentUser;
    public EmployeeService(IEmployeeRepository repo,ICurrentUserService currentUser)
    {
        _repo = repo;
        _currentUser = currentUser;
    }

    public async Task<List<EmployeeDto>> GetAllAsync()
    {
        var data = await _repo.GetAllAsync();
        return data.Select(MapToDto).ToList();
    }

    public async Task<EmployeeDto?> GetByIdAsync(Guid id)
    {
        var emp = await _repo.GetByIdAsync(id);
        return emp == null ? null : MapToDto(emp);
    }

    public async Task<List<EmployeeDto>> SearchAsync(string? keyword, string? department, string? designation, bool? isActive)
    {
        var data = await _repo.SearchAsync(keyword, department, designation, isActive);
        return data.Select(MapToDto).ToList();
    }
    public async Task<Guid> CreateAsync(CreateEmployeeDto dto)
    {
        var entity = new Employee
        {
            EmployeeId = Guid.NewGuid(),
            EmployeeCode = dto.EmployeeCode,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Department = dto.Department,
            Designation = dto.Designation,
            JoiningDate = dto.JoiningDate,
            IsActive = dto.IsActive,
            CreatedOn = DateTime.UtcNow,
            CreatedBy = _currentUser.UserName ?? "SYSTEM"
        };
        await _repo.AddAsync(entity);
        return entity.EmployeeId;
    }
    public async Task UpdateAsync(Guid id, CreateEmployeeDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return;
        existing.EmployeeCode = dto.EmployeeCode;
        existing.FirstName = dto.FirstName;
        existing.LastName = dto.LastName;
        existing.Email = dto.Email;
        existing.Department = dto.Department;
        existing.Designation = dto.Designation;
        existing.JoiningDate = dto.JoiningDate;
        existing.IsActive = dto.IsActive;
        existing.ModifiedOn = DateTime.UtcNow;
        existing.ModifiedBy = _currentUser.UserName ?? "SYSTEM";
        await _repo.UpdateAsync(existing);
    }

    public async Task DeleteAsync(Guid id)
    {
        var emp = await _repo.GetByIdAsync(id);
        if (emp != null)
            await _repo.DeleteAsync(emp);
    }

    private static EmployeeDto MapToDto(Employee e)
    {
        return new EmployeeDto
        {
            EmployeeId = e.EmployeeId,
            EmployeeCode = e.EmployeeCode,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Email = e.Email,
            Department = e.Department,
            Designation = e.Designation,
            JoiningDate = e.JoiningDate,
            IsActive = e.IsActive
        };
    }
    
    public async Task<EmployeeDashboardDto> GetDashboardAsync()
    {
        return await _repo.GetDashboardAsync();
    }

}