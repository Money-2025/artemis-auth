using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class PasswordResetRequestRepository : IPasswordResetRequestRepository
{
    private readonly AuthDbContext _context;

    public PasswordResetRequestRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<PasswordResetRequest?> GetByTokenAsync(string resetToken)
    {
        return await _context.PasswordResetRequests
            .FirstOrDefaultAsync(r => r.ResetToken == resetToken && !r.IsUsed);
    }

    public async Task AddAsync(PasswordResetRequest entity)
    {
        await _context.PasswordResetRequests.AddAsync(entity);
    }

    public async Task MarkAsUsedAsync(PasswordResetRequest entity)
    {
        entity.IsUsed = true;
        entity.UsedAt = DateTimeOffset.UtcNow;
        _context.PasswordResetRequests.Update(entity);
    }
}