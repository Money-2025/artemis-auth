using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data;

public class AuthDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Role> Roles { get; set; } = default!;
    public DbSet<UserRole> UserRoles { get; set; } = default!;
    public DbSet<UserMfaMethod> UserMfaMethods { get; set; } = default!;
    public DbSet<UserOtpCode> UserOtpCodes { get; set; } = default!;
    public DbSet<AuditLog> AuditLogs { get; set; } = default!;
    public DbSet<UserSession> UserSessions { get; set; } = default!;
    public DbSet<PasswordResetRequest> PasswordResetRequests { get; set; } = default!;
    public DbSet<RolePermission> RolePermissions { get; set; } = default!;
    public DbSet<MfaBackupCode> MfaBackupCodes { get; set; } = default!;
    public DbSet<DeviceTrust> DeviceTrusts { get; set; } = default!;
    public DbSet<PasswordHistory> PasswordHistories { get; set; } = default!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = default!;

    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Composite keys
        builder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.Permission });

        // Unique indexes
        builder.Entity<RefreshToken>()
            .HasIndex(rt => new { rt.UserId, rt.Token })
            .IsUnique();

        builder.Entity<UserSession>()
            .HasIndex(us => us.SessionToken)
            .IsUnique();

        builder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
    }
    
}