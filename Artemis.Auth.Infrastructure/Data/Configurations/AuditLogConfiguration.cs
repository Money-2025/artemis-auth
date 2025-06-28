using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Auth.Infrastructure.Data.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        // Tablo adı ve birincil anahtar
        builder.ToTable("audit_logs");
        builder.HasKey(a => a.Id);

        // Kolon ayarları
        builder.Property(a => a.TableName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(a => a.RecordId)
            .IsRequired();

        builder.Property(a => a.Action)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(a => a.OldData)
            .HasColumnType("jsonb");

        builder.Property(a => a.NewData)
            .HasColumnType("jsonb");

        builder.Property(a => a.PerformedAt)
            .HasDefaultValueSql("now() at time zone 'utc'");

        builder.Property(a => a.RowVersion)
            .IsConcurrencyToken()
            .HasDefaultValue(1);

        // İlişkiler
        builder.HasOne(a => a.PerformedByUser)
            .WithMany()
            .HasForeignKey(a => a.PerformedBy)
            .OnDelete(DeleteBehavior.SetNull);
    }
}