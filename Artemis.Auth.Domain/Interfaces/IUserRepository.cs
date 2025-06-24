using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);

    /// <summary>
    /// Adds a new User to the context (not yet saved to the database).
    /// </summary>
    Task AddAsync(User user);

    /// <summary>
    /// Marks an existing User as modified in the context (not yet saved).
    /// </summary>
    Task UpdateAsync(User user);

    /// <summary>
    /// Persists all pending changes (Add, Update, Delete) to the database.
    /// </summary>
    Task SaveChangesAsync();
}