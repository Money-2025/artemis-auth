using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Auth.Infrastructure.Data.Configurations;

public class MfaBackupCodeConfiguration : IEntityTypeConfiguration<MfaBackupCode>
{
    public void Configure(EntityTypeBuilder<MfaBackupCode> builder)
    {
        // Tablo adı ve birincil anahtar
        builder.ToTable("mfa_backup_codes");
        builder.HasKey(bc => bc.Id);

        // Kolon ayarları
        builder.Property(bc => bc.Code)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(bc => bc.IsUsed)
            .HasDefaultValue(false);

        builder.Property(bc => bc.CreatedAt)
            .HasDefaultValueSql("now() at time zone 'utc'")
            .IsRequired();

        builder.Property(bc => bc.UsedAt);

        builder.Property(bc => bc.RowVersion)
            .IsConcurrencyToken()
            .HasDefaultValue(1);

        // İlişkiler
        builder.HasOne(bc => bc.User)
            .WithMany(u => u.MfaBackupCodes)
            .HasForeignKey(bc => bc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}