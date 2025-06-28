using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Auth.Infrastructure.Data.Configurations;

public class UserOtpCodeConfiguration : IEntityTypeConfiguration<UserOtpCode>
{
    public void Configure(EntityTypeBuilder<UserOtpCode> builder)
    {
        // Tablo adı ve birincil anahtar
        builder.ToTable("user_otp_codes");
        builder.HasKey(o => o.Id);

        // Kolon ayarları
        builder.Property(o => o.OtpCode)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(o => o.ExpiresAt)
            .IsRequired();

        builder.Property(o => o.IsUsed)
            .HasDefaultValue(false);

        builder.Property(o => o.CreatedAt)
            .HasDefaultValueSql("now() at time zone 'utc'")
            .IsRequired();

        builder.Property(o => o.RowVersion)
            .IsConcurrencyToken()
            .HasDefaultValue(1);

        // İlişkiler
        builder.HasOne(o => o.User)
            .WithMany(u => u.OtpCodes)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(o => o.CreatedByUser)
            .WithMany()
            .HasForeignKey(o => o.CreatedBy)
            .OnDelete(DeleteBehavior.SetNull);;
    }
}