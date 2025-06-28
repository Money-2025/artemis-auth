using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;

public interface IRoleRepository
{
    Task<Role?> GetByIdAsync(Guid id);
    Task<IEnumerable<Role>> GetAllAsync();
    Task AddAsync(Role entity);
    Task UpdateAsync(Role entity);
    Task DeleteAsync(Role entity);
}