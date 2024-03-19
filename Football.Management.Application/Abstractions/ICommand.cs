using FluentResults;
using MediatR;

namespace Football.Management.Application.Abstractions;

public interface ICommand : IRequest<Result> {}
public interface ICommand<TResponse> : IRequest<Result<TResponse>> {}
