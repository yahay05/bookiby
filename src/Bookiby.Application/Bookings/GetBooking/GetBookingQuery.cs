using Bookiby.Application.Abstractions.Caching;
using Bookiby.Application.Abstractions.Messaging;

namespace Bookiby.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(string BookingId) : ICachedQuery<BookingResponse>
{
    public string CacheKey => $"bookings:{BookingId}";

    public TimeSpan? Expiration => null;
}