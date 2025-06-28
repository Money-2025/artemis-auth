using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;

public interface IMfaBackupCodeRepository
{
    Task<IEnumerable<MfaBackupCode>> GetByUserIdAsync(Guid userId);
    Task AddAsync(MfaBackupCode entity);
    Task MarkAsUsedAsync(MfaBackupCode entity);
}