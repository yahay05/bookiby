using Microsoft.AspNetCore.Authorization;

namespace Bookiby.Infrastructure.Authorization;

[AttributeUsage(AttributeTargets.All)]
public sealed class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission);