using Bookiby.Domain.Abstractions;

namespace Bookiby.Domain.Bookings.Events;

public sealed record BookingReservedDomainEvent(string BookingId) : IDomainEvent;