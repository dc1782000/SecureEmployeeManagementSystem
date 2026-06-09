namespace SecureEmployeeManagementSystem.Domain.Entities;

public class User: BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    
    public bool IsActive { get; set; }

}