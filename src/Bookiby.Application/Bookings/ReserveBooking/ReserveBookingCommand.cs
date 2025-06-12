using Bookiby.Application.Abstractions.Messaging;

namespace Bookiby.Application.Bookings.ReserveBooking;

public record ReserveBookingCommand(
    string ApartmentId,
    string UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<string>;