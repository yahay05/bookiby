using Bookiby.Domain.Abstractions;
using Bookiby.Domain.Bookings;
using Bookiby.Domain.Reviews.Events;

namespace Bookiby.Domain.Reviews;

public sealed class Review : Entity
{
    private Review(
        string id,
        string apartmentId,
        string bookingId,
        string userId,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc) : base(id)
    {
        ApartmentId = apartmentId;
        BookingId = bookingId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createdOnUtc;
    }

    private Review()
    {
        
    }

    public string ApartmentId { get; set; }
    public string BookingId { get; set; }
    public string UserId { get; set; }
    public Rating Rating { get; set; }
    public Comment Comment { get; set; }
    public DateTime CreatedOnUtc { get; set; }

    public static Result<Review> Create(
        Booking booking,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc)
    {
        if (booking.Status != BookingStatus.Completed)
        {
            return Result.Failure<Review>(ReviewErrors.NotEligible);
        }
        var review = new Review(
            Guid.NewGuid().ToString(),
            booking.ApartmentId,
            booking.Id,
            booking.UserId,
            rating,
            comment,
            createdOnUtc);
        
        review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));

        return review;
    }
}