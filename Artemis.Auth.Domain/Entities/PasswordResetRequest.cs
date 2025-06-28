namespace Artemis.Auth.Domain.Entities;

public class PasswordResetRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public string ResetToken { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public DateTimeOffset? UsedAt { get; set; }
    public bool IsUsed { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public User CreatedByUser { get; set; }
    public int RowVersion { get; set; }

}