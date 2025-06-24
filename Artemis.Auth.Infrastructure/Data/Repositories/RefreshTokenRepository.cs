using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AuthDbContext _ctx;

    public RefreshTokenRepository(AuthDbContext context)
    {
        _ctx = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Token must be provided", nameof(token));

        return await _ctx.RefreshTokens
            // no AsNoTracking: we may want to revoke/update it
            .FirstOrDefaultAsync(rt => rt.Token == token);
    }

    public async Task AddAsync(RefreshToken refreshToken)
    {
        if (refreshToken == null) 
            throw new ArgumentNullException(nameof(refreshToken));

        await _ctx.RefreshTokens.AddAsync(refreshToken);
    }

    public async Task UpdateAsync(RefreshToken refreshToken)
    {
        if (refreshToken == null) 
            throw new ArgumentNullException(nameof(refreshToken));

        _ctx.RefreshTokens.Update(refreshToken);
        await Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _ctx.SaveChangesAsync();
    }
}
