using Bookiby.Application.Abstractions.Clock;
using Bookiby.Application.Abstractions.Email;
using Bookiby.Domain.Bookings;
using Bookiby.Domain.Bookings.Events;
using Bookiby.Domain.Users;
using MediatR;

namespace Bookiby.Application.Bookings.ReserveBooking;

internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public BookingReservedDomainEventHandler(
        IBookingRepository bookingRepository,
        IUserRepository userRepository,
        IEmailService emailService)
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }
    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);

        if (booking == null)
        {
            return;
        }
        
        var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);
        if (user == null)
        {
            return;
        }
        
        await _emailService.SendAsync(user.Email,
            "Booking reserved booking",
            $"You have 10 minutes to confirm this booking {notification.BookingId}.");
    }
}