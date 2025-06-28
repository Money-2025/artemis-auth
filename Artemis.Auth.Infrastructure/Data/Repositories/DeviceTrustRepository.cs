using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class DeviceTrustRepository : IDeviceTrustRepository
{
    private readonly AuthDbContext _context;

    public DeviceTrustRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DeviceTrust>> GetTrustedDevicesAsync(Guid userId)
    {
        return await _context.DeviceTrusts
            .Where(dt => dt.UserId == userId)
            .OrderByDescending(dt => dt.LastUsedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(DeviceTrust entity)
    {
        await _context.DeviceTrusts.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(DeviceTrust entity)
    {
        _context.DeviceTrusts.Remove(entity);
        await _context.SaveChangesAsync();
    }

    // Additional useful methods you might want to implement:
    public async Task<DeviceTrust?> GetByDeviceIdAsync(Guid userId, Guid deviceId)
    {
        return await _context.DeviceTrusts
            .FirstOrDefaultAsync(dt => dt.UserId == userId && dt.Id == deviceId);
    }

    public async Task UpdateAsync(DeviceTrust entity)
    {
        _context.DeviceTrusts.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAllForUserAsync(Guid userId)
    {
        var devices = await _context.DeviceTrusts
            .Where(dt => dt.UserId == userId)
            .ToListAsync();

        _context.DeviceTrusts.RemoveRange(devices);
        await _context.SaveChangesAsync();
    }
}