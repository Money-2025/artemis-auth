using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class UserOtpCodeRepository : IUserOtpCodeRepository
{
    private readonly AuthDbContext _context;

    public UserOtpCodeRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<UserOtpCode?> GetByIdAsync(Guid id)
    {
        return await _context.UserOtpCodes.FindAsync(id);
    }

    public async Task<IEnumerable<UserOtpCode>> GetByUserIdAsync(Guid userId)
    {
        return await _context.UserOtpCodes
            .Where(code => code.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(UserOtpCode entity)
    {
        await _context.UserOtpCodes.AddAsync(entity);
    }

    public async Task MarkAsUsedAsync(UserOtpCode entity)
    {
        entity.IsUsed = true;
        _context.UserOtpCodes.Update(entity);
    }
}