using Bookiby.Application.Bookings.GetBooking;
using Bookiby.Application.Bookings.ReserveBooking;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookiby.Api.Controllers.Bookings;

[Authorize]
[ApiController]
[Route("bookings")]
public class BookingsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBooking(string id, CancellationToken cancellationToken)
    {
        var query = new GetBookingQuery(id);

        var result = await sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ReserveBooking(
        ReserveBookingRequest request,
        CancellationToken cancellationToken)
    {
        var command = new ReserveBookingCommand(
            request.ApartmentId,
            request.UserId,
            request.StartDate,
            request.EndDate);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return CreatedAtAction(nameof(GetBooking), new { id = result.Value }, result.Value);
    }
}