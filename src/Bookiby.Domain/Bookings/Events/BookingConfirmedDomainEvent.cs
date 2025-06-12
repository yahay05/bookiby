using Bookiby.Domain.Abstractions;

namespace Bookiby.Domain.Bookings.Events;

public record BookingConfirmedDomainEvent(string BookingId) : IDomainEvent;