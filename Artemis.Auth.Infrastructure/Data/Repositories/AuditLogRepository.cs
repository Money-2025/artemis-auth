using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class AuditLogRepository : IAuditLogRepository
{
    private readonly AuthDbContext _context;

    public AuditLogRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AuditLog entity)
    {
        await _context.AuditLogs.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<AuditLog>> GetByRecordAsync(string tableName, Guid recordId)
    {
        return await _context.AuditLogs
            .Where(log => log.TableName == tableName && log.RecordId == recordId)
            .OrderByDescending(log => log.RecordId)
            .ToListAsync();
    }
}