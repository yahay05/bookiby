namespace Bookiby.Application.Abstractions.Behaviors;

public record ValidationError(string PropertyName, string ErrorMessage);