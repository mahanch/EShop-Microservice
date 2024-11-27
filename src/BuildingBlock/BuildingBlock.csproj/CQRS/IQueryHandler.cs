using MediatR;

namespace BuildingBlock.csproj.CQRS;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
	where TQuery : IQuery<TResponse>
	where TResponse : notnull;
