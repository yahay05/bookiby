using System.Security.Claims;

namespace Bookiby.Infrastructure.Authentication;

public static class ClaimsPrincipalExtensions
{
    public static string GetIdentityId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(ClaimTypes.NameIdentifier) 
               ?? throw new ApplicationException("User identity id is unavailable.");
        }
}