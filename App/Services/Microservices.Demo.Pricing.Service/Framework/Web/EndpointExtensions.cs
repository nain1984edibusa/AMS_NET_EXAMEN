using Microservices.Demo.Pricing.Service.Framework.Rest.Endpoints;

namespace Microservices.Demo.Pricing.Service.Framework.Web
{
    public static class EndpointExtensions
    {
        public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPricingEndpoints();
            return app;
        }
    }
}
