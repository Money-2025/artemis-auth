using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;

public interface IRolePermissionRepository
{
    Task<IEnumerable<RolePermission>> GetByRoleIdAsync(Guid roleId);
    Task AddAsync(RolePermission entity);
    Task RemoveAsync(RolePermission entity);
}