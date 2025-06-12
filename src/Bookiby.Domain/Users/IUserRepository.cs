namespace Bookiby.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    void Add(User user);
}