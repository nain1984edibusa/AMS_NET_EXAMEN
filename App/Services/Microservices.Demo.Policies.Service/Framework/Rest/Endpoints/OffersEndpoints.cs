using Microservices.Demo.Policies.Service.Framework.Rest.Handlers;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Endpoints
{
    public static class OffersEndpoints
    {
        public static void MapOffersEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/offers").WithTags("Offers");

            group.MapPost("/", OffersHandlers.CreateOfferAsync);
        }
    }
}
