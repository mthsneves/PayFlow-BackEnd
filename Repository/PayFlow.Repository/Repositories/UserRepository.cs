using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interface;
using PayFlow.Repository.Data.DataConfiguration;

namespace PayFlow.Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var userByEmail = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        if (userByEmail != null)
        {
            return userByEmail;
        }

        return null;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        var userById = await _context.Users.FindAsync(id);
        if (userById != null)
        {
            return userById;
        }

        return null;
    }
}