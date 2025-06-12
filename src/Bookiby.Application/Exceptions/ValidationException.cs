using Bookiby.Application.Abstractions.Behaviors;
using FluentValidation.Results;

namespace Bookiby.Application.Exceptions;

public sealed class ValidationException : Exception
{
    public ValidationException(IEnumerable<ValidationError> errors)
    {
        Errors = errors;
    }
    
    public IEnumerable<ValidationError> Errors { get; }
}