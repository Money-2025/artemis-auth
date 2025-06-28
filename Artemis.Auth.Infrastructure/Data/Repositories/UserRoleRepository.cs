using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly AuthDbContext _context;
    public UserRoleRepository(AuthDbContext context) => _context = context;


    public async Task<UserRole?> GetAsync(Guid userId, Guid roleId)
    {
        return await _context.UserRoles
            .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
    }

    public async Task<IEnumerable<UserRole>> GetByUserIdAsync(Guid userId)
    {
        return await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(UserRole entity)
    {
        await _context.UserRoles.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(UserRole entity)
    {
        _context.UserRoles.Remove(entity);
        await _context.SaveChangesAsync();
    }
}