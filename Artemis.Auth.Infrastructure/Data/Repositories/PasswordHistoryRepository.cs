using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class PasswordHistoryRepository : IPasswordHistoryRepository
{
    private readonly AuthDbContext _context;
        
    public PasswordHistoryRepository(AuthDbContext context) 
        => _context = context;

    public async Task<IEnumerable<PasswordHistory>> GetByUserIdAsync(Guid userId)
    {
        return await _context.PasswordHistories
            .Where(ph => ph.UserId == userId)
            .OrderByDescending(ph => ph.ChangedAt)
            .ToListAsync();
    }

    public async Task AddAsync(PasswordHistory entity)
    {
        await _context.PasswordHistories.AddAsync(entity);
    }

}