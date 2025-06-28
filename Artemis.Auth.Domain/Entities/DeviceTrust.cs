namespace Artemis.Auth.Domain.Entities;

public class DeviceTrust
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public string DeviceName { get; set; }
    public DateTimeOffset TrustedAt { get; set; }
    public DateTimeOffset? LastUsedAt { get; set; }
    public bool IsRevoked { get; set; }
    public DateTimeOffset? RevokedAt { get; set; }
    public Guid? RevokedBy { get; set; }
    public User RevokedByUser { get; set; }
    public int RowVersion { get; set; }
}