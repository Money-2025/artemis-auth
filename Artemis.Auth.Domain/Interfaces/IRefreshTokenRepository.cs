using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;


public interface IRefreshTokenRepository
{
    /// <summary>
    /// Retrieves a refresh token entity by its token string.
    /// </summary>
    Task<RefreshToken?> GetByTokenAsync(string token);

    /// <summary>
    /// Adds a new RefreshToken to the context (not yet saved).
    /// </summary>
    Task AddAsync(RefreshToken refreshToken);

    /// <summary>
    /// Marks an existing RefreshToken as modified in the context (not yet saved).
    /// </summary>
    Task UpdateAsync(RefreshToken refreshToken);

    /// <summary>
    /// Persists all pending changes (Add, Update, Delete) to the database.
    /// </summary>
    Task SaveChangesAsync();
}