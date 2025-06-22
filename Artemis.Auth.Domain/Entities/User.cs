namespace Artemis.Auth.Domain.Entities;

public class User
{
    public Guid   Id           { get; private set; }
    public string Email        { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public bool   IsActive     { get; private set; } = true;
}