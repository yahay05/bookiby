using Bookiby.Application.Abstractions.Authentication;
using Bookiby.Domain.Users;
using Bookiby.Infrastructure.Authentication.Models;
using System.Net.Http.Json;

namespace Bookiby.Infrastructure.Authentication;

public class AuthenticationService(HttpClient httpClient) : IAuthenticationService
{
    private const string PasswordCredentialType = "password";

    public async Task<string> RegisterAsync(User user, string password, CancellationToken cancellationToken = default)
    {
        var userRepresentationModel = UserRepresentationModel.FromUser(user);

        userRepresentationModel.Credentials =
        [
            new() { Value = password, Temporary = false, Type = PasswordCredentialType }
        ];
        
        var response = await httpClient.PostAsJsonAsync(
            "users",
            userRepresentationModel,
            cancellationToken);
        
        return ExtractIdentityIdFromLocationHeader(response);
    }
    
    private static string ExtractIdentityIdFromLocationHeader(HttpResponseMessage response)
    {
        const string usersSegmentName = "users/";
        
        var locationHeader = response.Headers.Location?.PathAndQuery;
        
        if (locationHeader is null)
        {
            throw new InvalidOperationException("Location header can not be null");
        }
        
        var userSegmentValueIndex = locationHeader.IndexOf(
            usersSegmentName,
            StringComparison.InvariantCultureIgnoreCase);
        
        var userIdentityId = locationHeader.Substring(
            userSegmentValueIndex + usersSegmentName.Length);
        
        return userIdentityId;
    }
}