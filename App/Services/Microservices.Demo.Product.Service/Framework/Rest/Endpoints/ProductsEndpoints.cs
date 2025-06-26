using Microservices.Demo.Products.Service.Framework.Rest.Models.Responses;

namespace Microservices.Demo.Products.Service.Framework.Rest.Endpoints
{
    public static class ProductsEndpoints
    {
        public static void MapProductsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/products").WithTags("Products");

            group.MapGet("/", ProductsHandlers.GetAllProductsAsync);
            group.MapGet("/{code:alpha}", ProductsHandlers.GetProductByCodeAsync);
            group.MapPost("/", ProductsHandlers.CreateProductAsync);
            group.MapPost("/activate", ProductsHandlers.ActivateProductAsync);
            group.MapPost("/discontinue", ProductsHandlers.DiscontinueProductAsync);
        }
    }
}
