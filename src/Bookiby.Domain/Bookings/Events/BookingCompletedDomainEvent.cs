using Bookiby.Domain.Abstractions;

namespace Bookiby.Domain.Bookings.Events;

public record BookingCompletedDomainEvent(string BookingId) : IDomainEvent;