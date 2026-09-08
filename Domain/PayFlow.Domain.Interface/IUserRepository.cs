using PayFlow.Domain.Entities;

namespace PayFlow.Domain.Interface;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<User> CreateUserAsync(User user);
    Task<User?> GetUserByIdAsync(Guid id);
}

    