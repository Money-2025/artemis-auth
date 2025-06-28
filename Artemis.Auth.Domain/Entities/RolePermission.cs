namespace Artemis.Auth.Domain.Entities;

public class RolePermission
{
    public Guid RoleId { get; set; }
    public Role Role { get; set; }

    public string Permission { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public User CreatedByUser { get; set; }
    public int RowVersion { get; set; }
}