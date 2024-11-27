using MediatR;

namespace BuildingBlock.csproj.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull;