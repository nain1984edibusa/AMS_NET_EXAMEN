using Microservices.Demo.Policies.Search.Service.Framework.Rest.Handlers;

namespace Microservices.Demo.Policies.Search.Service.Framework.Rest.Endpoints
{
    public static class PoliciesEndpoints
    {
        public static void MapPoliciesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/policies").WithTags("Policies");

            group.MapGet("/", PoliciesHandler.FindPolicyAsync);            
        }
    }
}
