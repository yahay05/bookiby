using Bookiby.Application.Abstractions.Authentication;
using Bookiby.Application.Abstractions.Messaging;
using Bookiby.Domain.Abstractions;
using Bookiby.Domain.Users;

namespace Bookiby.Application.Users.RegisterUser;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;

    public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
    }

    public async Task<Result<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(
            new FirstName(request.FirstName),
            new LastName(request.LastName),
            new Email(request.Email));
        
        var identityId = await _authenticationService.RegisterAsync(
            user,
            request.Password,
            cancellationToken);
        
        user.SetIdentityId(identityId);
        
        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return user.Id;
    }
}