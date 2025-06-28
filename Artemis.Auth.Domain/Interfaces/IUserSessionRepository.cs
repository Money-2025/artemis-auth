using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;

public interface IUserSessionRepository
{
    Task<UserSession?> GetByTokenAsync(string sessionToken);
    Task<IEnumerable<UserSession>> GetByUserIdAsync(Guid userId);
    Task AddAsync(UserSession entity);
    Task UpdateAsync(UserSession entity);
}