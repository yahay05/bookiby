using Bookiby.Domain.Apartments;

namespace Bookiby.Domain.Bookings;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken);
    void Add(Booking booking);
}