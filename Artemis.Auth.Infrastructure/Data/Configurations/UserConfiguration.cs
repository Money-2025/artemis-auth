// File: Artemis.Auth.Infrastructure/Data/Configurations/UserConfiguration.cs
using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Auth.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table name and primary key
            builder.ToTable("users");
            builder.HasKey(u => u.Id);

            // Column settings
            builder.Property(u => u.Username)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasIndex(u => u.Username).IsUnique();

            builder.Property(u => u.NormalizedUsername)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasIndex(u => u.NormalizedUsername).IsUnique();

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.NormalizedEmail)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.HasIndex(u => u.NormalizedEmail).IsUnique();

            builder.Property(u => u.EmailConfirmed)
                   .HasDefaultValue(false);

            builder.Property(u => u.PhoneNumber)
                   .HasMaxLength(30);
            builder.Property(u => u.PhoneNumberConfirmed)
                   .HasDefaultValue(false);

            builder.Property(u => u.PasswordHash)
                   .IsRequired();

            builder.Property(u => u.SecurityStamp)
                   .HasMaxLength(200);

            builder.Property(u => u.TwoFactorEnabled)
                   .HasDefaultValue(false);

            builder.Property(u => u.IsDeleted)
                   .HasDefaultValue(false);

            builder.Property(u => u.LastLoginAt);

            builder.Property(u => u.FailedLoginCount)
                   .HasDefaultValue(0);

            builder.Property(u => u.LockoutEnd);

            builder.Property(u => u.CreatedAt)
                   .HasDefaultValueSql("now() at time zone 'utc'")
                   .IsRequired();

            builder.Property(u => u.CreatedBy);
            builder.Property(u => u.ModifiedAt);
            builder.Property(u => u.ModifiedBy);

            builder.Property(u => u.RowVersion)
                   .IsConcurrencyToken()
                   .HasDefaultValue(1);

            builder.Property(u => u.PasswordResetToken)
                   .HasMaxLength(200);

            builder.Property(u => u.PasswordResetExpiresAt);

            // Relationships
            builder.HasOne(u => u.CreatedByUser)
                   .WithMany()
                   .HasForeignKey(u => u.CreatedBy)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(u => u.ModifiedByUser)
                   .WithMany()
                   .HasForeignKey(u => u.ModifiedBy)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.UserRoles)
                   .WithOne(ur => ur.User)
                   .HasForeignKey(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.RefreshTokens)
                   .WithOne(rt => rt.User)
                   .HasForeignKey(rt => rt.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Sessions)
                   .WithOne(s => s.User)
                   .HasForeignKey(s => s.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.MfaMethods)
                   .WithOne(m => m.User)
                   .HasForeignKey(m => m.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.OtpCodes)
                   .WithOne(o => o.User)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.PasswordResetRequests)
                   .WithOne(pr => pr.User)
                   .HasForeignKey(pr => pr.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.RolePermissions)
                   .WithOne(rp => rp.CreatedByUser) // or appropriate navigation if you have direct relation
                   .HasForeignKey(rp => rp.CreatedBy)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.DeviceTrusts)
                   .WithOne(dt => dt.User)
                   .HasForeignKey(dt => dt.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.PasswordHistories)
                   .WithOne(ph => ph.User)
                   .HasForeignKey(ph => ph.UserId)
                   .OnDelete(DeleteBehavior.Cascade);throw new NotImplementedException();
        }
    }
}