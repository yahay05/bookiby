using Bookiby.Application.Abstractions.Caching;
using Bookiby.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Bookiby.Infrastructure.Authorization;

internal sealed class AuthorizationService(ApplicationDbContext dbContext, ICacheService cacheService)
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ICacheService _cacheService = cacheService;

    public async Task<UserRolesResponse> GetRolesForUserAsync(string identityId)
    {
        var cacheKey = $"auth:roles-{identityId}";
        
        var cacheRoles = await _cacheService.GetAsync<UserRolesResponse>(cacheKey);
        if (cacheRoles is not null)
            return cacheRoles;
        
        var roles = await _dbContext.Set<User>()
            .Where(user => user.IdentityId == identityId)
            .Select(user => new UserRolesResponse { Id = user.Id, Roles = user.Roles.ToList() })
            .FirstAsync();

        
        await _cacheService.SetAsync(cacheKey, roles, TimeSpan.FromMinutes(5));
        return roles;
    }
    
    public async Task<HashSet<string>> GetPermissionsForUserAsync(string identityId)
    {
        var cacheKey = $"auth:permissions-{identityId}";
        
        var cachePermissions = await _cacheService.GetAsync<HashSet<string>>(cacheKey);
        
        if (cachePermissions is not null)
            return cachePermissions;
        
        var permissions = await _dbContext.Set<User>()
           .Where(user => user.IdentityId == identityId)
           .SelectMany(user => user.Roles.Select(role => role.Permissions))
           .FirstAsync();
       
        HashSet<string> permissionSet = permissions.Select(p => p.Name).ToHashSet();
        
        await _cacheService.SetAsync(cacheKey, permissionSet, TimeSpan.FromMinutes(5));
        
        return permissionSet;
    }
}