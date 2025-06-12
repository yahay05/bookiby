using Bookiby.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;

namespace Bookiby.Infrastructure.Authentication;

public sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    
    public string IdentityId => _httpContextAccessor.HttpContext?.User.GetIdentityId() ??
                                throw new ApplicationException("User context is unavailable.");
}