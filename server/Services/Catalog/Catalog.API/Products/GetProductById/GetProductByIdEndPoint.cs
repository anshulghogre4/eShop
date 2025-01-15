
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductById
{
   
    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
             app.MapGet("/products/{Id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(Id));
                var response = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Prodict By Id")
            .WithDescription("Get Prodict By Id");
        }
    }
}
