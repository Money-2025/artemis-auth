using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AuthDbContext _context;

    public RefreshTokenRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await _context.RefreshTokens
            .FirstOrDefaultAsync(rt => rt.Token == token);
    }

    public async Task<IEnumerable<RefreshToken>> GetByUserIdAsync(Guid userId)
    {
        return await _context.RefreshTokens
            .Where(rt => rt.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(RefreshToken token)
    {
        await _context.RefreshTokens.AddAsync(token);
    }

    public void Update(RefreshToken token)
    {
        _context.RefreshTokens.Update(token);
    }

    public void Delete(RefreshToken token)
    {
        _context.RefreshTokens.Remove(token);
    }
}
