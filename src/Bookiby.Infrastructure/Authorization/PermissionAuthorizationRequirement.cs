using Microsoft.AspNetCore.Authorization;

namespace Bookiby.Infrastructure.Authorization;

internal sealed class PermissionAuthorizationRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}