using Microservices.Demo.Policies.Service.Framework.Rest.Handlers;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Endpoints
{
    public static class PoliciesEndpoints
    {
        public static void MapPoliciesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/policies").WithTags("Policies");

            group.MapGet("/", PoliciesHandlers.GetAllPoliciesAsync);
            group.MapGet("/by-number/{policyNumber:guid}", PoliciesHandlers.GetPolicyDetailsByNumberAsync);
            group.MapGet("/by-id/{policyId:guid}", PoliciesHandlers.GetHolderByPolicyIdAsync);
            group.MapPost("/", PoliciesHandlers.CreatePolicyAsync);
            group.MapDelete("/terminate", PoliciesHandlers.TerminatePolicyAsync);
        }
    }
}
