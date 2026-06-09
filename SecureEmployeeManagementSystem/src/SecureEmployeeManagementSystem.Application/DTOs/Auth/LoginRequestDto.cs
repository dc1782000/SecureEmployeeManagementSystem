using System.ComponentModel.DataAnnotations;

namespace SecureEmployeeManagementSystem.Application.DTOs.Auth;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Username is required")]
    [MinLength(2, ErrorMessage = "Username must be at least 2 characters")]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [MinLength(7, ErrorMessage = "Password must be at least 7 characters")]
    public string Password { get; set; } = string.Empty;
}