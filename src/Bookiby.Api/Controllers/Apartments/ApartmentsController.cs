using Bookiby.Application.Apartments.SearchApartments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookiby.Api.Controllers.Apartments;

[Authorize]
[ApiController]
[Route("apartments")]
public class ApartmentsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> SearchApartments(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken)
    {
        var query = new SearchApartmentsQuery(startDate, endDate);
        
        var result = await sender.Send(query, cancellationToken);
        
        return Ok(result.Value);
    }
}