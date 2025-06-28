using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;

public interface IUserMfaMethodRepository
{
    Task<UserMfaMethod?> GetByIdAsync(Guid id);
    Task<IEnumerable<UserMfaMethod>> GetByUserIdAsync(Guid userId);
    Task AddAsync(UserMfaMethod entity);
    Task UpdateAsync(UserMfaMethod entity);
    Task DeleteAsync(UserMfaMethod entity);
}