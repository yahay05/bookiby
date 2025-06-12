using Bookiby.Application.Abstractions.Messaging;

namespace Bookiby.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : ICommand<string>;