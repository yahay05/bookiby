using Bookiby.Domain.Users;

namespace Bookiby.Infrastructure.Repositories;

public sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override void Add(User user)
    {
        foreach (Role role in user.Roles)
        {
            DbContext.Attach(role);
        }

        DbContext.Add(user);
    }
}