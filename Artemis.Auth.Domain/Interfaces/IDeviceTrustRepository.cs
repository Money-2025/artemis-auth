using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;

public interface IDeviceTrustRepository
{
    Task<IEnumerable<DeviceTrust>> GetTrustedDevicesAsync(Guid userId);
    Task AddAsync(DeviceTrust entity);
    Task RemoveAsync(DeviceTrust entity);
}