namespace Artemis.Auth.Domain.Entities;

public class UserRole
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid RoleId { get; set; }
    public Role Role { get; set; }

    public DateTimeOffset AssignedAt { get; set; }
    public Guid? AssignedBy { get; set; }
    public User AssignedByUser { get; set; }
}