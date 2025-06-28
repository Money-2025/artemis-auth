using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Auth.Infrastructure.Data.Configurations;

public class DeviceTrustConfiguration : IEntityTypeConfiguration<DeviceTrust>
{
    public void Configure(EntityTypeBuilder<DeviceTrust> builder)
    {
        // Tablo adı ve birincil anahtar
        builder.ToTable("device_trusts");
        builder.HasKey(dt => dt.Id);

        // Kolon ayarları
        builder.Property(dt => dt.DeviceName)
            .HasMaxLength(200);

        builder.Property(dt => dt.TrustedAt)
            .HasDefaultValueSql("now() at time zone 'utc'")
            .IsRequired();

        builder.Property(dt => dt.LastUsedAt);

        builder.Property(dt => dt.IsRevoked)
            .HasDefaultValue(false);

        builder.Property(dt => dt.RevokedAt);

        builder.Property(dt => dt.RevokedBy);

        builder.Property(dt => dt.RowVersion)
            .IsConcurrencyToken()
            .HasDefaultValue(1);

        // İlişkiler
        builder.HasOne(dt => dt.User)
            .WithMany(u => u.DeviceTrusts) // User entity'sine DeviceTrusts koleksiyonunu eklediğinizden emin olun
            .HasForeignKey(dt => dt.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(dt => dt.RevokedByUser)
            .WithMany()
            .HasForeignKey(dt => dt.RevokedBy)
            .OnDelete(DeleteBehavior.SetNull);
    }
}