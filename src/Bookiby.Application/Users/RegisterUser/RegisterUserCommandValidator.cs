using FluentValidation;

namespace Bookiby.Application.Users.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.Email).EmailAddress();
        RuleFor(c => c.Password).NotEmpty().MinimumLength(8);
    }
}