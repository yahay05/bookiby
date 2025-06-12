using Bookiby.Application.Abstractions.Email;

namespace Bookiby.Infrastructure.Email;

public sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email email, string subject, string body)
    {
        Console.WriteLine($"The email sent to {email},\n subject: {subject},\n body: {body}");
        return Task.CompletedTask;
    }
}