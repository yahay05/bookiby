using Bookiby.Application.Abstractions.Messaging;

namespace Bookiby.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(string BookingId) : IQuery<BookingResponse>;