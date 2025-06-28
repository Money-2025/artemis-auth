namespace Artemis.Auth.Domain.Entities;

public class UserSession
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public string SessionToken { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? LastAccessAt { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public string IpAddress { get; set; }
    public string UserAgent { get; set; }
    public bool IsRevoked { get; set; }
    public DateTimeOffset? RevokedAt { get; set; }
    public Guid? RevokedBy { get; set; }
    public User RevokedByUser { get; set; }
    public int RowVersion { get; set; }

}