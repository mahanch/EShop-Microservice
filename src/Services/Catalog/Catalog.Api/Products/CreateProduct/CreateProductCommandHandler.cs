using BuildingBlock.csproj.CQRS;
using Catalog.Api.Models;
using Marten;
using MediatR;

namespace Catalog.Api.Products.CreateProduct;

public record CreateProductCommand(
	string Name,
	List<string> Categories,
	string Description,
	double Price,
	string ImageFile):ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler(IDocumentSession session):ICommandHandler<CreateProductCommand,CreateProductResult>
{
	public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
	{
		var product = new Product
		{
			Categories = command.Categories,
			Description = command.Description,
			Price = command.Price,
			ImageFile = command.ImageFile,
			Name = command.Name
		};
		
		session.Store(product);

		await session.SaveChangesAsync(cancellationToken);

		return new CreateProductResult(product.Id);
	}
}