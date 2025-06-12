using Bookiby.Domain.Abstractions;

namespace Bookiby.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(string UserId) : IDomainEvent;