using Artemis.Auth.Domain.Entities;
using Artemis.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Auth.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    public AuthDbContext _context { get; set; }

    public UserRepository(AuthDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetByIdAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        return user;
    }

    public async Task<User?> GetByUsernameAsync(string normalizedUsername)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.NormalizedUsername == normalizedUsername);
        return user;
    }

    public async Task<User?> GetByEmailAsync(string normalizedEmail)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.NormalizedEmail == normalizedEmail);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
       var userList = await _context.Users.ToListAsync();
         return userList;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
    }
}