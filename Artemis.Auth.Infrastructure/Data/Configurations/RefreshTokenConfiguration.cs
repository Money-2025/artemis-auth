// File: Artemis.Auth.Infrastructure/Data/Configurations/RefreshTokenConfiguration.cs
using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Auth.Infrastructure.Data.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            // Tablo adı ve birincil anahtar
            builder.ToTable("refresh_tokens");
            builder.HasKey(rt => rt.Id);

            // Kolon ayarları
            builder.Property(rt => rt.Token)
                .IsRequired()
                .HasMaxLength(200);
            builder.HasIndex(rt => rt.Token)
                .IsUnique();

            builder.Property(rt => rt.ExpiresAt)
                .IsRequired();

            builder.Property(rt => rt.CreatedAt)
                .HasDefaultValueSql("now() at time zone 'utc'")
                .IsRequired();

            builder.Property(rt => rt.CreatedByIp)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(rt => rt.RevokedAt);

            builder.Property(rt => rt.RevokedByIp)
                .HasMaxLength(45);

            builder.Property(rt => rt.ReplacedByToken)
                .HasMaxLength(200);

            builder.Property(rt => rt.RevocationReason)
                .HasMaxLength(500);

            builder.Property(rt => rt.RowVersion)
                .IsConcurrencyToken()
                .HasDefaultValue(1);

            builder.HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}