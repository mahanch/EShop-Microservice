

namespace Catalog.Api.Products.CreateProduct;

public record CreateProductRequest(
	string Name,
	List<string> Categories,
	string Description,
	double Price,
	string ImageFile);

public record CreateProductResponse(Guid Id);
public class CreateProductEndpoint:ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
		{

		}).WithName("CreateProduct")
		.Produces<CreateProductResponse>(StatusCodes.Status201Created)
		.ProducesProblem(StatusCodes.Status400BadRequest)
		.WithSummary("Create Product")
		.WithDescription("Create Product");
	}
}