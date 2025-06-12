using Bookiby.Domain.Abstractions;
using MediatR;

namespace Bookiby.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}