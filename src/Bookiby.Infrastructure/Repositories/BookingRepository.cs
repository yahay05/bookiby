using Bookiby.Domain.Apartments;
using Bookiby.Domain.Bookings;
using Microsoft.EntityFrameworkCore;

namespace Bookiby.Infrastructure.Repositories;

public sealed class BookingRepository : Repository<Booking>, IBookingRepository
{
    private static readonly BookingStatus[] ActiveBookingStatus =
    {
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    };
    public BookingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken)
    {
        return await DbContext
            .Set<Booking>()
            .AnyAsync(
                booking => 
                    booking.ApartmentId == apartment.Id &&
                    booking.Duration.Start == duration.Start &&
                    booking.Duration.End == duration.End &&
                    ActiveBookingStatus.Contains(booking.Status),
                cancellationToken);
    }
}