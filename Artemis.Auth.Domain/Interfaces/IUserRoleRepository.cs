using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;

public interface IUserRoleRepository
{
    Task<UserRole?> GetAsync(Guid userId, Guid roleId);
    Task<IEnumerable<UserRole>> GetByUserIdAsync(Guid userId);
    Task AddAsync(UserRole entity);
    Task RemoveAsync(UserRole entity);
}