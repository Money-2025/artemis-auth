// File: Artemis.Auth.Infrastructure/Data/Configurations/UserConfiguration.cs
using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Auth.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> e)
        {
            e.ToTable("Users");
            e.HasKey(u => u.Id);

            e.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);

            e.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);
            e.HasIndex(u => u.Email)
                .IsUnique();

            e.Property(u => u.PasswordHash)
                .IsRequired();

            e.Property(u => u.IsEmailConfirmed)
                .HasDefaultValue(false);

            e.Property(u => u.CreatedAt)
                .HasDefaultValueSql("NOW()");

            // One-to-many with RefreshToken
            e.HasMany(u => u.RefreshTokens)
                .WithOne(rt => rt.User)
                .HasForeignKey(rt => rt.UserId);
        }
    }
}