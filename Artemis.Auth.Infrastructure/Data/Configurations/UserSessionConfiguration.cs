using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Auth.Infrastructure.Data.Configurations;

public class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>
{
    public void Configure(EntityTypeBuilder<UserSession> builder)
    {
        // Table name and primary key
        builder.ToTable("user_sessions");
        builder.HasKey(us => us.Id);

        // Column settings
        builder.Property(us => us.SessionToken)
            .IsRequired()
            .HasMaxLength(200);
        builder.HasIndex(us => us.SessionToken)
            .IsUnique();

        builder.Property(us => us.CreatedAt)
            .HasDefaultValueSql("now() at time zone 'utc'")
            .IsRequired();

        builder.Property(us => us.LastAccessAt);

        builder.Property(us => us.ExpiresAt)
            .IsRequired();

        builder.Property(us => us.IpAddress)
            .HasMaxLength(45);

        builder.Property(us => us.UserAgent);

        builder.Property(us => us.IsRevoked)
            .HasDefaultValue(false);

        builder.Property(us => us.RevokedAt);

        builder.Property(us => us.RevokedBy);

        builder.Property(us => us.RowVersion)
            .IsConcurrencyToken()
            .HasDefaultValue(1);

        // Relationships
        builder.HasOne(us => us.User)
            .WithMany(u => u.Sessions)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(us => us.RevokedByUser)
            .WithMany()
            .HasForeignKey(us => us.RevokedBy)
            .OnDelete(DeleteBehavior.SetNull);
    }
}