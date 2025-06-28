using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;

public interface IUserOtpCodeRepository
{
    Task<UserOtpCode?> GetByIdAsync(Guid id);
    Task<IEnumerable<UserOtpCode>> GetByUserIdAsync(Guid userId);
    Task AddAsync(UserOtpCode entity);
    Task MarkAsUsedAsync(UserOtpCode entity);

}