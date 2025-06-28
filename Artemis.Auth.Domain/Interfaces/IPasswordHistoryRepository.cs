using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;

public interface IPasswordHistoryRepository
{
    Task<IEnumerable<PasswordHistory>> GetByUserIdAsync(Guid userId);
    Task AddAsync(PasswordHistory entity);
}