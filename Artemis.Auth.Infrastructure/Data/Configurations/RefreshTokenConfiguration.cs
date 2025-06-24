// File: Artemis.Auth.Infrastructure/Data/Configurations/RefreshTokenConfiguration.cs
using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Auth.Infrastructure.Data.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> e)
        {
            e.ToTable("RefreshTokens");
            e.HasKey(rt => rt.Id);

            e.Property(rt => rt.Token)
                .IsRequired()
                .HasMaxLength(200);
            e.HasIndex(rt => rt.Token)
                .IsUnique();

            e.Property(rt => rt.Created)
                .HasDefaultValueSql("NOW()");
            e.Property(rt => rt.Expires)
                .IsRequired();

            e.Property(rt => rt.CreatedByIp)
                .IsRequired()
                .HasMaxLength(45);

            e.Property(rt => rt.RevokedByIp)
                .HasMaxLength(45);

            e.Property(rt => rt.RevocationReason)
                .HasMaxLength(500);

            // Relationship back to User is configured in UserConfiguration
        }
    }
}