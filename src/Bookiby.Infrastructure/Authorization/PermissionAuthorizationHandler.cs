using Bookiby.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Bookiby.Infrastructure.Authorization;

internal sealed class PermissionAuthorizationHandler(IServiceProvider serviceProvider)
    : AuthorizationHandler<PermissionAuthorizationRequirement>
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionAuthorizationRequirement requirement)
    {
        if (context.User.Identity is not { IsAuthenticated: true})
        {
            return;
        }
        
        using var scope = _serviceProvider.CreateScope();
        var authorizationService = scope.ServiceProvider.GetRequiredService<AuthorizationService>();

        var identityId = context.User.GetIdentityId();
        
        HashSet<string> permissions = await authorizationService.GetPermissionsForUserAsync(identityId);
        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }
}