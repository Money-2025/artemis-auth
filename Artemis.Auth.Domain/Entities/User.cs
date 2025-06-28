using System.ComponentModel.DataAnnotations;

namespace Artemis.Auth.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Username { get; set; } = null!;
        public string NormalizedUsername { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string NormalizedEmail { get; set; } = null!;
        public bool EmailConfirmed { get; set; }

        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        public string PasswordHash { get; set; } = null!;
        public string? SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? LastLoginAt { get; set; }
        public int FailedLoginCount { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public Guid? CreatedBy { get; set; }
        public User? CreatedByUser { get; set; }

        public DateTimeOffset? ModifiedAt { get; set; }
        public Guid? ModifiedBy { get; set; }
        public User? ModifiedByUser { get; set; }

        [ConcurrencyCheck]
        public int RowVersion { get; set; }

        // Password reset flow
        public string? PasswordResetToken { get; set; }
        public DateTimeOffset? PasswordResetExpiresAt { get; set; }

        // Navigation properties for related tables
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public ICollection<UserSession> Sessions { get; set; } = new List<UserSession>();
        public ICollection<UserMfaMethod> MfaMethods { get; set; } = new List<UserMfaMethod>();
        public ICollection<UserOtpCode> OtpCodes { get; set; } = new List<UserOtpCode>();
        public ICollection<PasswordResetRequest> PasswordResetRequests { get; set; }
            = new List<PasswordResetRequest>();
        public ICollection<RolePermission> Permissions { get; set; }
            = new List<RolePermission>();
        public ICollection<DeviceTrust> DeviceTrusts { get; set; }
            = new List<DeviceTrust>();
        public ICollection<MfaBackupCode> MfaBackupCodes { get; set; }
            = new List<MfaBackupCode>();
        public ICollection<PasswordHistory> PasswordHistories { get; set; }
            = new List<PasswordHistory>();
        public ICollection<UserRole> UserRoles { get; set; }
            = new List<UserRole>();
        public ICollection<RolePermission> RolePermissions { get; set; }
            = new List<RolePermission>();

    }
}
