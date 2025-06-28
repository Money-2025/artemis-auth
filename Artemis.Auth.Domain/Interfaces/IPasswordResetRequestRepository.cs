using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;

public interface IPasswordResetRequestRepository
{
    Task<PasswordResetRequest?> GetByTokenAsync(string resetToken);
    Task AddAsync(PasswordResetRequest entity);
    Task MarkAsUsedAsync(PasswordResetRequest entity);
}