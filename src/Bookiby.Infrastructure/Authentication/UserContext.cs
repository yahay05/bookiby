using Bookiby.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;

namespace Bookiby.Infrastructure.Authentication;

public sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public string UserId => _httpContextAccessor.HttpContext?.User.GetUserId() ??
                            throw new ApplicationException("User context is unavailable.");

    public string IdentityId => _httpContextAccessor.HttpContext?.User.GetIdentityId() ??
                                throw new ApplicationException("User context is unavailable.");
}