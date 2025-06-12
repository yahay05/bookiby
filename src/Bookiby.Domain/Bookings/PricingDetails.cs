using Bookiby.Domain.Apartments;
using Bookiby.Domain.Shared;

namespace Bookiby.Domain.Bookings;

public record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);