namespace SecureEmployeeManagementSystem.Domain.Entities;

public abstract class BaseAuditableEntity
{
    public DateTime CreatedOn { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public string? ModifiedBy { get; set; }
}