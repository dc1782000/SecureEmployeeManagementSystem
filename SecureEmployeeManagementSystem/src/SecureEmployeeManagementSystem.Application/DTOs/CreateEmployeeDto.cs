using System.ComponentModel.DataAnnotations;

namespace SecureEmployeeManagementSystem.Application.DTOs;

public class CreateEmployeeDto
{
    [Required]
    public string EmployeeCode { get; set; } = string.Empty;
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Department { get; set; } = string.Empty;
    [Required]
    public string Designation { get; set; } = string.Empty;
    [Required]
    public DateTime JoiningDate { get; set; }
    public bool IsActive { get; set; }
}