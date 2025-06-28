using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class MfaBackupCodeRepository : IMfaBackupCodeRepository
{
    private readonly AuthDbContext _context;

    public MfaBackupCodeRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MfaBackupCode>> GetByUserIdAsync(Guid userId)
    {
        return await _context.MfaBackupCodes
            .Where(code => code.UserId == userId && !code.IsUsed)
            .ToListAsync();
    }

    public async Task AddAsync(MfaBackupCode entity)
    {
        await _context.MfaBackupCodes.AddAsync(entity);
    }

    public async Task MarkAsUsedAsync(MfaBackupCode entity)
    {
        entity.IsUsed = true;
        _context.MfaBackupCodes.Update(entity);
    }
}