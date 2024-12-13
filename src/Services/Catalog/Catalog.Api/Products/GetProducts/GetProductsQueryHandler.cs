using BuildingBlock.csproj.CQRS;
using Catalog.Api.Models;
using Marten;
using Microsoft.AspNetCore.Identity;

namespace Catalog.Api.Products.GetProducts;

public record GetProductQuery() : IQuery<GetProductResult>;

public record GetProductResult(IEnumerable<Product> Products);
internal class GetProductsQueryHandler(IDocumentSession session,ILogger<GetProductsQueryHandler> logger)
	:IQueryHandler<GetProductQuery,GetProductResult>
{
	public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
	{
		logger.LogInformation("GetProductQueryHandler.Handle Called With {@Query}",query);

		var products = await session.Query<Product>().ToListAsync(cancellationToken);

		return new GetProductResult(products);
	}
}