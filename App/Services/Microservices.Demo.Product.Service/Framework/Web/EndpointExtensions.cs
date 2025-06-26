using Microservices.Demo.Products.Service.Framework.Rest.Endpoints;

namespace Microservices.Demo.Products.Service.Framework.Web
{
    public static class EndpointExtensions
    {
        public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapProductsEndpoints();
            return app;
        }
    }
}
