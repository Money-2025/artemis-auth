using System.ComponentModel.DataAnnotations;

namespace Artemis.Auth.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public string Token { get; set; } = null!;
        public DateTimeOffset ExpiresAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public string CreatedByIp { get; set; } = null!;

        public DateTimeOffset? RevokedAt { get; set; }
        public string? RevokedByIp { get; set; }
        public string? ReplacedByToken { get; set; }
        public string? RevocationReason { get; set; }

        [ConcurrencyCheck]
        public int RowVersion { get; set; }

        // Convenience
        public bool IsExpired => DateTimeOffset.UtcNow >= ExpiresAt;
        public bool IsActive  => RevokedAt == null && !IsExpired;
    }
}