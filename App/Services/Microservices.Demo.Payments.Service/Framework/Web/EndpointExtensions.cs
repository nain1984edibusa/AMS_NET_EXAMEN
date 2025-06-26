using Microservices.Demo.Payments.Service.Framework.Rest.Endpoints;

namespace Microservices.Demo.Payments.Service.Framework.Rest.Web
{
    public static class EndpointExtensions
    {
        public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPolicyAccountsEndpoints();
            return app;
        }
    }
}
