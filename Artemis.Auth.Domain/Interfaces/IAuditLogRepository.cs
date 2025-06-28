using Artemis.Auth.Domain.Entities;

namespace Artemis.Auth.Domain.Interfaces;

public interface IAuditLogRepository
{
    Task AddAsync(AuditLog entity);
    Task<IEnumerable<AuditLog>> GetByRecordAsync(string tableName, Guid recordId);
}