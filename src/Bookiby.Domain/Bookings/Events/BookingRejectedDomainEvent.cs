using Bookiby.Domain.Abstractions;

namespace Bookiby.Domain.Bookings.Events;

public record BookingRejectedDomainEvent(string BookingId) : IDomainEvent;