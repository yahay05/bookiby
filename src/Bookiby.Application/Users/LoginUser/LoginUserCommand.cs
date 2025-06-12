using Bookiby.Application.Abstractions.Messaging;

namespace Bookiby.Application.Users.LoginUser;

public record LoginUserCommand(string Email, string Password) : ICommand<AccessTokenResponse>;
