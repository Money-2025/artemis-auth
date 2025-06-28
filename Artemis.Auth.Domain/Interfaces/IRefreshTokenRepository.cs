using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;


public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByTokenAsync(string token);
    Task<IEnumerable<RefreshToken>> GetByUserIdAsync(Guid userId);
    Task AddAsync(RefreshToken token);
    void Update(RefreshToken token);
    void Delete(RefreshToken token);
}