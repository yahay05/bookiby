namespace Bookiby.Application.Abstractions.Authentication;

public interface IUserContext
{
    string UserId { get; }
    string IdentityId { get; }
}