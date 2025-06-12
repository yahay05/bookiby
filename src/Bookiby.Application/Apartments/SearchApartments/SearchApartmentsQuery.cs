using Bookiby.Application.Abstractions.Messaging;
using Bookiby.Application.Bookings.GetBooking;
using Bookiby.Domain.Abstractions;

namespace Bookiby.Application.Apartments.SearchApartments;

public sealed record SearchApartmentsQuery(DateOnly StartDate, DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;