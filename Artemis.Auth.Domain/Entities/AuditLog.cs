namespace Artemis.Auth.Domain.Entities;

public class AuditLog
{
    public Guid Id { get; set; }
    public string TableName { get; set; }
    public Guid RecordId { get; set; }
    public string Action { get; set; }           // INSERT, UPDATE, DELETE
    public string OldData { get; set; }          // JSONB içerik
    public string NewData { get; set; }
    public DateTimeOffset PerformedAt { get; set; }
    public Guid? PerformedBy { get; set; }
    public User PerformedByUser { get; set; }
    public int RowVersion { get; set; }
}