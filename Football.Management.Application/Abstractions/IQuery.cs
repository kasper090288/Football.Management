using FluentResults;
using MediatR;

namespace Football.Management.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> {}
