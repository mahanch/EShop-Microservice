﻿using BuildingBlock.csproj.CQRS;
using Catalog.Api.Models;
using Marten;

namespace Catalog.Api.Products.GetProductsByCategory;

public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);

internal class GetProductByCategoryQueryHandler
	(IDocumentSession session)
	: IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
	public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
	{
		var products = await session.Query<Product>()
			.Where(p => p.Categories.Contains(query.Category))
			.ToListAsync(cancellationToken);

		return new GetProductByCategoryResult(products);
	}
}