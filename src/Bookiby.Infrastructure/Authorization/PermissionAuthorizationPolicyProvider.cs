using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Bookiby.Infrastructure.Authorization;

public sealed class PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
    : DefaultAuthorizationPolicyProvider(options)
{
    private readonly AuthorizationOptions _authorizationOptions = options.Value;

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);

        if (policy is not null)
        {
            return policy;
        }
        
        var permissionPlicy = new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionAuthorizationRequirement(policyName))
            .Build();
        
        _authorizationOptions.AddPolicy(policyName, permissionPlicy);
        
        return permissionPlicy;
    }
}