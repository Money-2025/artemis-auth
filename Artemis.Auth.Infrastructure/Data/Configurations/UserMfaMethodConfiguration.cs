using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Auth.Infrastructure.Data.Configurations;

public class UserMfaMethodConfiguration : IEntityTypeConfiguration<UserMfaMethod>
{
    public void Configure(EntityTypeBuilder<UserMfaMethod> builder)
    {
        // Table name and primary key
        builder.ToTable("user_mfa_methods");
        builder.HasKey(m => m.Id);

        // Column settings
        builder.Property(m => m.Type)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.IsEnabled)
            .HasDefaultValue(false);

        builder.Property(m => m.CreatedAt)
            .HasDefaultValueSql("now() at time zone 'utc'")
            .IsRequired();

        builder.Property(m => m.RowVersion)
            .IsConcurrencyToken()
            .HasDefaultValue(1);

        // Relationships
        builder.HasOne(m => m.User)
            .WithMany(u => u.MfaMethods)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.CreatedByUser)
            .WithMany()
            .HasForeignKey(m => m.CreatedBy)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(m => m.ModifiedByUser)
            .WithMany()
            .HasForeignKey(m => m.ModifiedBy)
            .OnDelete(DeleteBehavior.SetNull);
    }
}