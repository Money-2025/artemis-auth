using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class RoleRepository : IRoleRepository
{
    public Task<Role?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Role>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Role entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Role entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Role entity)
    {
        throw new NotImplementedException();
    }
}