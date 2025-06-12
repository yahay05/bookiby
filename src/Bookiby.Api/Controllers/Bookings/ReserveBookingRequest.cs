namespace Bookiby.Api.Controllers.Bookings;

public sealed record ReserveBookingRequest(string ApartmentId, string UserId, DateOnly StartDate, DateOnly EndDate);