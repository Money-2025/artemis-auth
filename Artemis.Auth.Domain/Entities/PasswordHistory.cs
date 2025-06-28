namespace Artemis.Auth.Domain.Entities;

public class PasswordHistory
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public string PasswordHash { get; set; }
    public DateTimeOffset ChangedAt { get; set; }
    public Guid? ChangedBy { get; set; }
    public User ChangedByUser { get; set; }
    public int RowVersion { get; set; }
}