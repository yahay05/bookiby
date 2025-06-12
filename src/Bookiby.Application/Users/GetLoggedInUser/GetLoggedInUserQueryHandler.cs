using Bookiby.Application.Abstractions.Authentication;
using Bookiby.Application.Abstractions.Messaging;
using Bookiby.Application.Data;
using Bookiby.Domain.Abstractions;
using Dapper;

namespace Bookiby.Application.Users.GetLoggedInUser;

public sealed record GetLoggedInUserQueryHandler : IQueryHandler<GetLoggedInUserQuery, UserResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IUserContext _userContext;

    public GetLoggedInUserQueryHandler(ISqlConnectionFactory sqlConnectionFactory, IUserContext userContext)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _userContext = userContext;
    }

    public async Task<Result<UserResponse>> Handle(GetLoggedInUserQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
                           SELECT
                            id AS Id,
                            first_name AS FirstName,
                            last_name AS LastName,
                            email AS Email
                           FROM users
                           WHERE identity_id = @IdentityId;
                           """;
        
        var user = await connection.QuerySingleAsync<UserResponse>(sql,
            new { _userContext.IdentityId });

        return user;
    }
}