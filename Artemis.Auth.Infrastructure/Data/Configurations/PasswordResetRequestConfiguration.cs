using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Auth.Infrastructure.Data.Configurations;

public class PasswordResetRequestConfiguration : IEntityTypeConfiguration<PasswordResetRequest>
{
    public void Configure(EntityTypeBuilder<PasswordResetRequest> builder)
    {
        builder.ToTable("password_reset_requests");
        builder.HasKey(pr => pr.Id);

        // Kolon ayarları
        builder.Property(pr => pr.ResetToken)
            .IsRequired()
            .HasMaxLength(200);
        builder.HasIndex(pr => pr.ResetToken)
            .IsUnique();

        builder.Property(pr => pr.ExpiresAt)
            .IsRequired();

        builder.Property(pr => pr.UsedAt);

        builder.Property(pr => pr.IsUsed)
            .HasDefaultValue(false);

        builder.Property(pr => pr.CreatedAt)
            .HasDefaultValueSql("now() at time zone 'utc'");

        builder.Property(pr => pr.RowVersion)
            .IsConcurrencyToken()
            .HasDefaultValue(1);

        // İlişkiler
        builder.HasOne(pr => pr.User)
            .WithMany(u => u.PasswordResetRequests)
            .HasForeignKey(pr => pr.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pr => pr.CreatedByUser)
            .WithMany()
            .HasForeignKey(pr => pr.CreatedBy)
            .OnDelete(DeleteBehavior.SetNull);
    }
}