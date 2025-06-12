using Bookiby.Application.Users.GetLoggedInUser;
using Bookiby.Application.Users.LoginUser;
using Bookiby.Application.Users.RegisterUser;
using Bookiby.Infrastructure.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookiby.Api.Controllers.Users;


[ApiController]
[Route("users")]
public class UsersController(ISender sender) : ControllerBase
{
    [HttpGet("me")]
    //[Authorize(Roles = Roles.Registered)]
    [HasPermission(Permissions.UsersRead)]
    public async Task<IActionResult> GetLoggedInUser(CancellationToken cancellationToken)
    {
        var query = new GetLoggedInUserQuery();
        
        var result = await sender.Send(query, cancellationToken);
        
        return Ok(result.Value);
        
    }
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        RegisterUserRequest request, 
        CancellationToken cancellationToken)
    {
        var command = new RegisterUserCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);
        
        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return Ok(result.Value);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = new LoginUserCommand(
            request.Email,
            request.Password);
        
        var result = await sender.Send(command, cancellationToken);
        
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return Ok(result.Value);
    }
}