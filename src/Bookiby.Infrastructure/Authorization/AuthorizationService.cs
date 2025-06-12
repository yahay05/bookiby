using Bookiby.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Bookiby.Infrastructure.Authorization;

internal sealed class AuthorizationService(ApplicationDbContext dbContext)
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<UserRolesResponse> GetRolesForUserAsync(string identityId)
    {
        var roles = await _dbContext.Set<User>()
            .Where(user => user.IdentityId == identityId)
            .Select(user => new UserRolesResponse { Id = user.Id, Roles = user.Roles.ToList() })
            .FirstAsync();

        return roles;
    }
    
    public async Task<HashSet<string>> GetPermissionsForUserAsync(string identityId)
    {
       var permissions = await _dbContext.Set<User>()
           .Where(user => user.IdentityId == identityId)
           .SelectMany(user => user.Roles.Select(role => role.Permissions))
           .FirstAsync();
       
       var permissionSet = permissions.Select(p => p.Name).ToHashSet();
       return permissionSet;
    }
}