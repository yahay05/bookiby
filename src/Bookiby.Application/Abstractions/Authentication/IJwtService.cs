using Bookiby.Domain.Abstractions;

namespace Bookiby.Application.Abstractions.Authentication;

public interface IJwtService
{
    Task<Result<string>> GetAccessTokenAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default);
}