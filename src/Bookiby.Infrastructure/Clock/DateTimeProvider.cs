using Bookiby.Application.Abstractions.Clock;

namespace Bookiby.Infrastructure.Clock;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}