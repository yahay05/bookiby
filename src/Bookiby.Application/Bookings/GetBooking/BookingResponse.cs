namespace Bookiby.Application.Bookings.GetBooking;

public sealed class BookingResponse
{
    public string Id { get; init; }
    public string UserId { get; init; }
    public string ApartmentId { get; init; }
    public int Status { get; init; }
    public decimal PriceAmount { get; init; }
    public string PriceCurrency { get; init; }
    public decimal CleaningFeeAmount { get; init; }
    public string CleaningFeeCurrency { get; init; }
    public decimal AmenitiesUpChargesAmount { get; init; }
    public string AmenitiesUpChargesCurrency { get; init; }
    public decimal TotalPriceAmount { get; init; }
    public string TotalPriceCurrency { get; init; }
    public DateOnly DurationStart { get; init; }
    public DateOnly DurationEnd { get; init; }
    public DateTime CreatedOnUtc { get; init; }
}