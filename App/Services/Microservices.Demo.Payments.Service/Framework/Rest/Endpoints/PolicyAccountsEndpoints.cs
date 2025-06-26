using Microservices.Demo.Payments.Service.Framework.Rest.Handlers;

namespace Microservices.Demo.Payments.Service.Framework.Rest.Endpoints
{
    public static class ProductsEndpoints
    {
        public static void MapPolicyAccountsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/accounts").WithTags("Accounts");

            group.MapGet("/{policyNumber:guid}", PolicyAccountsHandler.GetPolicyAccountByNumberAsync);            
        }
    }
}