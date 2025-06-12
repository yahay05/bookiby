using Bookiby.Application.Abstractions.Messaging;

namespace Bookiby.Application.Users.GetLoggedInUser;

public sealed record GetLoggedInUserQuery : IQuery<UserResponse>;