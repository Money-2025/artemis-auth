namespace Artemis.Auth.Domain.Entities;

public class UserMfaMethod
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public string Type { get; set; }             // sms, email, authenticator
    public bool IsEnabled { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public User CreatedByUser { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public Guid? ModifiedBy { get; set; }
    public User ModifiedByUser { get; set; }
    public int RowVersion { get; set; }
}