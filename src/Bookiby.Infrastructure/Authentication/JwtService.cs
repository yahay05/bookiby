using Bookiby.Application.Abstractions.Authentication;
using Bookiby.Domain.Abstractions;
using Bookiby.Infrastructure.Authentication.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Bookiby.Infrastructure.Authentication;

public sealed class JwtService(IOptions<KeycloakOptions> keycloakOptions, HttpClient httpClient)
    : IJwtService
{
    private static readonly Error AuthenticationFailed = new(
        "Keycloak.AuthenticationFailed",
        "Failed to acquire access token do to authentication failure");

    private readonly KeycloakOptions _keycloakOptions = keycloakOptions.Value;


    public async Task<Result<string>> GetAccessTokenAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        try
        {
            var authRequestParameters = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "client_id", _keycloakOptions.AuthClientId },
                { "client_secret", _keycloakOptions.AuthClientSecret },
                { "username", email },
                { "password", password },
                {"scope", "openid email"}
            };
            
            var authRequestContent = new FormUrlEncodedContent(authRequestParameters);
            
            var response = await httpClient.PostAsync("", authRequestContent, cancellationToken);

            response.EnsureSuccessStatusCode();

            var authorizationToken = await response.Content.ReadFromJsonAsync<AuthorizationToken>(cancellationToken);
            
            return authorizationToken?.AccessToken ?? Result.Failure<string>(AuthenticationFailed);
        }
        catch (HttpRequestException)
        {
            return Result.Failure<string>(AuthenticationFailed);
        }
    }
}