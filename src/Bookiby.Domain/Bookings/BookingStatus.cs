namespace Bookiby.Domain.Bookings;

public enum BookingStatus
{
    Reserved = 1,
    Confirmed,
    Rejected,
    Cancelled,
    Completed,
}