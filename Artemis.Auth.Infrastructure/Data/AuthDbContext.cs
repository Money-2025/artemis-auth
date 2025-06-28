using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // All entity configurations (keys, indices, relationships, defaults, concurrency tokens, etc.)
        // are defined in their respective IEntityTypeConfiguration<T> classes.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
    }
    
}