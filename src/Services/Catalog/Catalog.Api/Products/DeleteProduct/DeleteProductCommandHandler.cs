using BuildingBlock.csproj.CQRS;
using Catalog.Api.Models;
using Marten;

namespace Catalog.Api.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResponse>;

public record DeleteProductResponse(bool IsSuccess);
internal class DeleteProductCommandHandler(IDocumentSession session):ICommandHandler<DeleteProductCommand,DeleteProductResponse>
{
	public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
	{
		session.Delete<Product>(request.Id);
		await session.SaveChangesAsync(cancellationToken);

		return new DeleteProductResponse(true);
	}
}