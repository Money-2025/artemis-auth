using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class UserMfaMethodRepository : IUserMfaMethodRepository
{
    private readonly AuthDbContext _context;

    public UserMfaMethodRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<UserMfaMethod?> GetByIdAsync(Guid id)
    {
        return await _context.UserMfaMethods.FindAsync(id);
    }

    public async Task<IEnumerable<UserMfaMethod>> GetByUserIdAsync(Guid userId)
    {
        return await _context.UserMfaMethods
            .Where(m => m.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(UserMfaMethod entity)
    {
        await _context.UserMfaMethods.AddAsync(entity);
    }

    public Task UpdateAsync(UserMfaMethod entity)
    {
        _context.UserMfaMethods.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(UserMfaMethod entity)
    {
        _context.UserMfaMethods.Remove(entity);
        return Task.CompletedTask;
    }
}