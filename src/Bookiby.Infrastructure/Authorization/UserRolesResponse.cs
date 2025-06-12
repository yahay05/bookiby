using Bookiby.Domain.Users;

namespace Bookiby.Infrastructure.Authorization;

public sealed class UserRolesResponse
{
    public string Id { get; init; }
    public List<Role> Roles { get; init; }
}