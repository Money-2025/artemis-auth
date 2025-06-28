using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Auth.Infrastructure.Data.Configurations;

public class PasswordHistoryConfiguration : IEntityTypeConfiguration<PasswordHistory>
{
    public void Configure(EntityTypeBuilder<PasswordHistory> builder)
    {
        // Tablo adı ve birincil anahtar
        builder.ToTable("password_history");
        builder.HasKey(ph => ph.Id);

        // Kolon ayarları
        builder.Property(ph => ph.PasswordHash)
            .IsRequired();

        builder.Property(ph => ph.ChangedAt)
            .HasDefaultValueSql("now() at time zone 'utc'")
            .IsRequired();

        builder.Property(ph => ph.RowVersion)
            .IsConcurrencyToken()
            .HasDefaultValue(1);

        // İlişkiler
        builder.HasOne(ph => ph.User)
            .WithMany(u => u.PasswordHistories)
            .HasForeignKey(ph => ph.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ph => ph.ChangedByUser)
            .WithMany()
            .HasForeignKey(ph => ph.ChangedBy)
            .OnDelete(DeleteBehavior.SetNull);

    }
}