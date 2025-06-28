namespace Artemis.Auth.Domain.Entities;

public class UserOtpCode
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public string OtpCode { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public bool IsUsed { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public User CreatedByUser { get; set; }
    public int RowVersion { get; set; }
}