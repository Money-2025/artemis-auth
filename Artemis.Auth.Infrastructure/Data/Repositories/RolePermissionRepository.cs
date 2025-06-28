using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly AuthDbContext _context;

    public RolePermissionRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RolePermission>> GetByRoleIdAsync(Guid roleId)
    {
        return await _context.RolePermissions
            .Where(rp => rp.RoleId == roleId)
            .ToListAsync();
    }

    public async Task AddAsync(RolePermission entity)
    {
        await _context.RolePermissions.AddAsync(entity);
    }

    public async Task RemoveAsync(RolePermission entity)
    {
        _context.RolePermissions.Remove(entity);
    }
}