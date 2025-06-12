using Bookiby.Domain.Abstractions;

namespace Bookiby.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(string ReviewId) : IDomainEvent;