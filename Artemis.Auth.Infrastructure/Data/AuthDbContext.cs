using Artemis.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data;

public class AuthDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;
    
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(e =>
        {
            e.ToTable("Users");
            e.HasKey(u => u.Id);
            e.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);
            e.Property(u => u.PasswordHash)
                .IsRequired();
            e.Property(u => u.IsActive)
                .HasDefaultValue(true);
        });
    }
    
}