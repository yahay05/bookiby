using Bookiby.Domain.Abstractions;

namespace Bookiby.Domain.Users;

public static class UserErrors
{
    public static Error NotFound = new Error(
        "User.NotFound", 
        "The user with the specified identifier was not found.");

    public static Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "The provided credentials were invalid.");
}