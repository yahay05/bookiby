using Bookiby.Application.Abstractions.Authentication;
using Bookiby.Application.Abstractions.Messaging;
using Bookiby.Application.Data;
using Bookiby.Domain.Abstractions;
using Bookiby.Domain.Bookings;
using Dapper;

namespace Bookiby.Application.Bookings.GetBooking;

public sealed class GetBookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory, IUserContext userContext)
    : IQueryHandler<GetBookingQuery, BookingResponse>
{
    public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        using var connection = sqlConnectionFactory.CreateConnection();
        const string sql = """
                           SELECT
                               id AS Id,
                               apartment_id AS ApartmentId,
                               user_id AS UserId,
                               status AS Status,
                               price_for_period_amount AS PriceAmount,
                               price_for_period_currency AS PriceCurrency,
                               cleaning_fee_amount AS CleaningFeeAmount,
                               cleaning_fee_currency AS CleaningFeeCurrency,
                               amenities_up_charge_amount AS AmenitiesUpCharge,
                               amenities_up_charge_currency AS AmenitiesUpChargeCurrency,
                               total_price_amount AS TotalPriceAmount,
                               total_price_currency AS TotalPriceCurrency,
                               duration_start AS DurationStart,
                               duration_end AS DurationEnd,
                               created_on_utc AS CreatedOnUtc
                           FROM bookings 
                           WHERE id = @BookingId
                           """;
        var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
            sql,
            new { request.BookingId });

        if (booking is null || booking.UserId != userContext.UserId)
        {
            return Result.Failure<BookingResponse>(BookingErrors.NotFound);
        }
        return booking;
    }
}