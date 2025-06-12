using Bookiby.Domain.Abstractions;

namespace Bookiby.Domain.Bookings.Events;

public sealed record BookingCancelledDomainEvent(string BookingId) : IDomainEvent;