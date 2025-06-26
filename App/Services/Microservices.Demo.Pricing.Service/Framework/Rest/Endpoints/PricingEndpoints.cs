using Microservices.Demo.Pricing.Service.Framework.Rest.Handlers;

namespace Microservices.Demo.Pricing.Service.Framework.Rest.Endpoints
{
    public static class PricingEndpoints
    {
        public static void MapPricingEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/pricing").WithTags("Pricing");
                        
            group.MapPost("/calculate-price", PricingHandlers.CalculatePriceAsync);
        }
    }
}
